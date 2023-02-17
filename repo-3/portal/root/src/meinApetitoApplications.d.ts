import { EntryPoint, ICurrentUserData, MeinApetitoApplication } from "@apetito/portal-sdk-common";
export declare function configureApplications(meinApetitoApplications: MeinApetitoApplication[], singleSpaApplications: any, userDataLoader: any): void;
export declare function getMeinApetitoApplications(): MeinApetitoApplication[];
export interface ApplicationAndEntryPointForUrl {
    url: URL;
    pathSegments: string[];
    applicationFound: boolean;
    application: MeinApetitoApplication;
    entryPointFound: boolean;
    hasEntryPoints: boolean;
    entryPoint: EntryPoint;
}
export declare function findApplicationAndEntryPointByUrl(meinApetitoApplications: MeinApetitoApplication[], url: URL): ApplicationAndEntryPointForUrl;
export declare function isNavigationGranted(applicationAndEntryPoint: ApplicationAndEntryPointForUrl, userDataLoader: () => ICurrentUserData): boolean;
