/* eslint-disable no-console */
import {
  navigateToUrl,
  registerApplication,
  start,
  triggerAppChange,
  unloadApplication,
} from "single-spa";
import {
  constructApplications,
  constructLayoutEngine,
  constructRoutes,
} from "single-spa-layout";
import {
  authentication,
  getBearerToken,
  useCurrentUserDataLoader,
  appInsights,
  ICurrentUserData,
} from "@apetito/portal-sdk-common";
import {
  configureApplications,
  findApplicationAndEntryPointByUrl,
  isNavigationGranted,
} from "./meinApetitoApplications";
import microfrontendLayout from "./microfrontend-layout.html";
import applications from "./config/applications";
import { userDataEventBus } from "./utils/currentUserDataLoader";

type SSPARoutingDetails = {
  detail: {
    newAppStatuses: Record<string, unknown>;
    appsByNewStatus: {
      NOT_MOUNTED: unknown[];
      NOT_LOADED: unknown[];
      MOUNTED: unknown[];
      SKIP_BECAUSE_BROKEN: unknown[];
    };
    totalAppChanges: number;
    originalEvent: void;
    oldUrl: string;
    newUrl: string;
    navigationIsCanceled: boolean;
  };
};

const routes = constructRoutes(microfrontendLayout);
const singleSpaApplications = constructApplications({
  routes,
  loadApp({ name }) {
    return System.import(name);
  },
});
const userDataLoader = useCurrentUserDataLoader();

let currentUserData: ICurrentUserData = null;

try {
  authentication.onAccountChanged(async (newAccount) => {
    const isSignedIn = authentication.isSignedIn();
    console.log("Root config: account changed", newAccount);
    console.log(`Root config: currentUser is logged in: ${isSignedIn} `);
    if (!isSignedIn) {
      return navigateToUrl("/");
    }

    getBearerToken()
      .then(() => {
        userDataLoader(true).then(({ reload, result }) => {
          userDataEventBus.publish({
            payload: result,
            type: "UserDataLoaded",
          });
          if (result) {
            currentUserData = result;
          }
          if (reload) {
            triggerAppChange(); // re-evaluates the activity function
            // Dashboard is configured to not need a login, so we have to re-mount the app when user data is loaded.
            unloadApplication("@apetito/dashboard");
          }
        });
      })
      .catch((error: Error) => {
        appInsights.trackEvent({
          name: "Login_Portal_Root_ApetitoRootConfig_GetBearerToken",
          properties: {
            customerNumbers: currentUserData?.customers,
            error: error,
          },
        });
      });
  });
} catch (error: unknown) {
  appInsights.trackEvent({
    name: "Login_Portal_Root_ApetitoRootConfig_OnAccountChanged",
    properties: {
      customerNumbers: currentUserData?.customers,
      error: error,
    },
  });
}

window.addEventListener(
  "single-spa:before-routing-event",
  (evt: Event & SSPARoutingDetails) => {
    console.log("before-routing-event", { evt, applications });

    const eventDetails = evt.detail;
    const newUrl = new URL(eventDetails.newUrl);
    const applicationAndEntryPoint = findApplicationAndEntryPointByUrl(
      applications,
      newUrl
    );

    if (!applicationAndEntryPoint.applicationFound) {
      console.error(
        `We do not know where you want to go. Navigation is not allowed. Going back to dashboard`
      );
      navigateToUrl("/");
      return;
    }

    if (!isNavigationGranted(applicationAndEntryPoint)) {
      console.error(`Navigation is not allowed. Going back to dashboard`);
      navigateToUrl("/");
    }
  }
);

configureApplications(applications, singleSpaApplications);

const layoutEngine = constructLayoutEngine({
  routes,
  applications: singleSpaApplications,
});

singleSpaApplications.forEach(registerApplication);
layoutEngine.activate();
start({
  // needed for vue3 router to work properly (especially when using the browser back button)
  urlRerouteOnly: true,
});
