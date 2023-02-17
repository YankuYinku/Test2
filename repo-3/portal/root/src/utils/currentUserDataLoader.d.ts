import { ICurrentUserData } from "@apetito/portal-sdk-common";
export declare function useCurrentUserDataLoader(): (reload?: boolean) => ICurrentUserData;
export declare function getCurrentUsersPermissions(userDataLoader: () => ICurrentUserData): string[];
export declare function extractUserPermissionsAsStringArray(userData: ICurrentUserData): string[];
