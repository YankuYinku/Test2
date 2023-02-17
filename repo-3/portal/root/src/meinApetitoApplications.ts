/* eslint-disable no-console */
import {
  combineActivities,
  combineActivitiesOr,
  hasUserData,
  ifHasPermission,
  ifLoggedIn,
  ifPathMatches,
} from "./activityFunctionComposition";

import {
  EntryPoint,
  isApplicationGranted,
  isEntryPointGranted,
  MeinApetitoApplication,
} from "@apetito/portal-sdk-common";
import { getCurrentUsersPermissions } from "./utils/currentUserDataLoader";

export interface ApplicationAndEntryPointForUrl {
  url: URL;
  pathSegments: string[];
  applicationFound: boolean;
  application: MeinApetitoApplication;
  entryPointFound: boolean;
  hasEntryPoints: boolean;
  entryPoint: EntryPoint;
}

export function configureApplications(
  meinApetitoApplications: MeinApetitoApplication[],
  singleSpaApplications
) {
  meinApetitoApplications.forEach(async (meinApetitoApplication) => {
    const { name, path, paths, isDefault, requiresLogin } =
      meinApetitoApplication;

    const singleSpaApplication = singleSpaApplications.find(
      (app) => app.name === name
    );

    if (typeof singleSpaApplication !== "undefined") {
      if (!isDefault && paths && Array.isArray(paths) && paths.length > 0) {
        singleSpaApplication.activeWhen = combineActivitiesOr(
          ...paths.map((path) => ifPathMatches(path))
        );
      } else if (!isDefault && path) {
        singleSpaApplication.activeWhen = ifPathMatches(path);
      }

      if (requiresLogin) {
        console.log(`:DEBUG: App ${name} requires login.`);

        singleSpaApplication.activeWhen = combineActivities(
          singleSpaApplication.activeWhen,
          ifLoggedIn(),
          hasUserData()
        );
      }

      if (isGuarded(meinApetitoApplication)) {
        const neededPermissions = getApplicationPermissions(
          meinApetitoApplication
        );

        singleSpaApplication.activeWhen = combineActivities(
          singleSpaApplication.activeWhen,
          ifHasPermission(neededPermissions)
        );
      }

      singleSpaApplication.customProps = {
        applications: meinApetitoApplications,
      };
    }
  });
}

function isGuarded(meinApetitoApplication: MeinApetitoApplication): boolean {
  const appIsGuarded =
    !!meinApetitoApplication.neededPermissions?.filter(Boolean)?.length;

  if (appIsGuarded) {
    return true;
  }

  return meinApetitoApplication.entryPoints?.every(
    (entryPoint) => !!entryPoint?.neededPermissions?.length
  );
}

function getApplicationPermissions(
  meinApetitoApplication: MeinApetitoApplication
): string[] {
  let permissions: string[] = [];

  if (!isGuarded(meinApetitoApplication)) {
    return [];
  }

  permissions.push(...(meinApetitoApplication.neededPermissions || []));

  if (meinApetitoApplication.entryPoints) {
    const entryPointsPermissions = meinApetitoApplication.entryPoints.flatMap(
      (entryPoint) => entryPoint.neededPermissions
    );

    permissions.push(...entryPointsPermissions);
  }

  return permissions;
}

export function findApplicationAndEntryPointByUrl(
  meinApetitoApplications: MeinApetitoApplication[],
  url: URL
): ApplicationAndEntryPointForUrl {
  const segments = buildSanitizedSegments(url);

  if (segments.length === 0) {
    console.warn(`No segments in url ${url} - returning default application`);
    const defaultApplication = meinApetitoApplications.find(
      (app) => app.isDefault
    );

    return {
      url,
      pathSegments: [],
      applicationFound: true,
      application: defaultApplication,
      hasEntryPoints: false,
      entryPointFound: false,
      entryPoint: undefined,
    };
  }

  return getApplicationsWithEntryPoints(meinApetitoApplications, segments, url);
}

function buildSanitizedSegments(url: URL) {
  const pathSegments = url.pathname.replace(/^\/+/, "").split("/");
  const hashSegments = url.hash.replace("#", "").replace(/^\/+/, "").split("/");

  return [...pathSegments, ...hashSegments].filter(Boolean);
}

function getApplicationsWithEntryPoints(
  initialMeinApetitoApplications: MeinApetitoApplication[],
  segments: string[],
  url: URL
): ApplicationAndEntryPointForUrl | undefined {
  let applicationsAndEntryPoints = initialMeinApetitoApplications.flatMap(
    (app) => {
      const pathSegments = app.path?.replace(/^\/+/, "")?.split("/") ?? [];

      if (!app.entryPoints) {
        return {
          url,
          pathSegments,
          application: app,
          entryPoint: undefined,
          hasEntryPoints: false,
        };
      }

      return app.entryPoints.map((entryPoint) => {
        const entryPointPathSegments =
          entryPoint.path?.replace("#", "")?.replace(/^\/+/, "")?.split("/") ??
          [];
        const newApp = { ...app };
        newApp.entryPoints = newApp.entryPoints.filter(
          (newEntryPoint) => newEntryPoint.name === entryPoint.name
        );

        return {
          pathSegments: [...pathSegments, ...entryPointPathSegments].filter(
            Boolean
          ),
          application: newApp,
          entryPoint: entryPoint,
          hasEntryPoints: true,
        };
      });
    }
  );

  while (applicationsAndEntryPoints.length > 1 && segments.length > 0) {
    let segment = segments.splice(0, 1)[0];

    applicationsAndEntryPoints = applicationsAndEntryPoints
      .filter((app) => app.pathSegments[0] === segment)
      .map((app) => ({
        pathSegments: app.pathSegments.slice(1),
        application: app.application,
        entryPoint: app.entryPoint,
        hasEntryPoints: app.hasEntryPoints,
      }));
  }

  if (applicationsAndEntryPoints.length > 1) {
    console.warn(`Can not find unique application for segments ${url}`);
    return {
      url: url,
      pathSegments: [],
      applicationFound: false,
      application: undefined,
      entryPointFound: false,
      entryPoint: undefined,
      hasEntryPoints: false,
    };
  }

  if (applicationsAndEntryPoints.length === 0) {
    console.warn(`Can not find any application for url ${url}`);
    return {
      url: url,
      pathSegments: [],
      applicationFound: false,
      application: undefined,
      entryPointFound: false,
      entryPoint: undefined,
      hasEntryPoints: false,
    };
  }

  // we found exactly one application
  return applicationsAndEntryPoints.map((app) => ({
    url: url,
    pathSegments: app.pathSegments,
    applicationFound: true,
    application: app.application,
    entryPointFound: app.entryPoint !== undefined,
    entryPoint: app.entryPoint,
    hasEntryPoints: app.hasEntryPoints,
  }))[0];
}

export function isNavigationGranted(
  applicationAndEntryPoint: ApplicationAndEntryPointForUrl
): boolean {
  const permissions = getCurrentUsersPermissions();

  if (permissions === undefined) {
    console.warn(
      "Permissions not yet loaded - we grant the navigation due to lack of knowledge"
    );
    return true;
  }

  const isApplicationGrantedResult = isApplicationGranted(
    applicationAndEntryPoint.application,
    permissions
  );
  const isEntryPointGrantedResult = // application has no entry points so this is not relevant for the decission
    !applicationAndEntryPoint.hasEntryPoints ||
    // application has entry points so we must have found exactly one and this one must be granted for the user
    (applicationAndEntryPoint.entryPointFound &&
      isEntryPointGranted(applicationAndEntryPoint.entryPoint, permissions));

  return isApplicationGrantedResult && isEntryPointGrantedResult;
}
