import {
  ICurrentUserData,
  getUserDataEventBusInstance,
} from "@apetito/portal-sdk-common";

export const userDataEventBus = getUserDataEventBusInstance();

export function getCurrentUsersPermissions(): string[] {
  const { payload } = userDataEventBus.getLastEvent() || {};

  return extractUserPermissionsAsStringArray(payload);
}

export function extractUserPermissionsAsStringArray(
  userData: ICurrentUserData
): string[] {
  if (userData === undefined) return undefined;

  return userData?.all?.permissions?.map((permission) => permission.name) ?? [];
}
