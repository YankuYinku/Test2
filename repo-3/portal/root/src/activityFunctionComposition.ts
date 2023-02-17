import { Activity, ActivityFn, pathToActiveWhen } from "single-spa";
import {
  authentication,
  appInsights,
  ICurrentUserData,
  getEventBusInstance,
} from "@apetito/portal-sdk-common";
import {
  getCurrentUsersPermissions,
  userDataEventBus,
} from "./utils/currentUserDataLoader";

function convertActivityToActivityFn(activity: Activity): ActivityFn {
  if (typeof activity === "string") {
    return ifPathMatches(activity);
  } else if ((activity as ActivityFn).call !== undefined) {
    return activity as ActivityFn;
  } else if (Array.isArray(activity)) {
    return combineActivityFunctions(
      ...activity.map((a) => convertActivityToActivityFn(a))
    );
  }
}

export function ifPathMatches(path: string): ActivityFn {
  return (location) => pathToActiveWhen(path)(location);
}

export function ifLoggedIn(): ActivityFn {
  const getUserDataEventBusInstance = getEventBusInstance<ICurrentUserData>(
    "@apetito/sspa-user-data"
  );
  const { payload } = getUserDataEventBusInstance.getLastEvent() || {};

  try {
    return (_) => authentication.isSignedIn() as boolean;
  } catch (error) {
    appInsights.trackEvent({
      name: "Login_Portal_Root_ActivityFunctionComposition_IsSignedIn",
      properties: {
        customerNumbers: payload?.customers,
        error: error,
      },
    });
  }
}

export function ifHasPermission(requestedPermissions: string[]) {
  return () => {
    const permissions = getCurrentUsersPermissions();

    if (!permissions?.length) {
      return false;
    }

    if (requestedPermissions.length === 0) {
      return true;
    }

    return requestedPermissions.some((permission) =>
      permissions.includes(permission)
    );
  };
}

export function hasUserData() {
  return () => {
    const { payload } = userDataEventBus.getLastEvent() || {};
    return !!payload?.customers;
  };
}

export function combineActivities(...items: Activity[]): ActivityFn {
  const activityFns = items.map((element) =>
    convertActivityToActivityFn(element)
  );
  return combineActivityFunctions(...activityFns);
}
export function combineActivitiesOr(...items: Activity[]): ActivityFn {
  const activityFns = items.map((element) =>
    convertActivityToActivityFn(element)
  );
  return combineOrActivityFunctions(...activityFns);
}

function combineActivityFunctions(...functions: ActivityFn[]): ActivityFn {
  const reducer =
    (prev: ActivityFn, curr: ActivityFn) => (location: Location) =>
      prev(location) && curr(location);
  return functions.reduce(reducer);
}

function combineOrActivityFunctions(...functions: ActivityFn[]): ActivityFn {
  const reducer =
    (prev: ActivityFn, curr: ActivityFn) => (location: Location) =>
      prev(location) || curr(location);
  return functions.reduce(reducer);
}
