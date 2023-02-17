import { MeinApetitoApplication } from "@apetito/portal-sdk-common";

export const applications: MeinApetitoApplication[] = [
  {
    name: "@apetito/dashboard",
    requiresLogin: false,
    isDefault: true,
    entryPoints: [
      {
        name: "signin",
        path: "#/signin",
      },
      {
        name: "news",
        path: "#/news",
      },
      {
        name: "dashboard",
        path: "#/dashboard",
      },
    ],
  },
  {
    name: "@apetito/legal",
    requiresLogin: false,
    path: "privacy-policy",
  },
  {
    name: "@apetito/user-account",
    requiresLogin: true,
  },
  {
    name: "@apetito/user-account-details",
    requiresLogin: true,
    path: "user-account-details",
    neededPermissions: [],
    entryPoints: [
      {
        name: "my-profile",
        neededPermissions: [],
        path: "#/my-profile",
      },
      {
        name: "my-company",
        neededPermissions: ["read:user-account.company"],
        path: "#/my-company",
      },
      {
        name: "orders",
        neededPermissions: ["read:user-account.orderHistory"],
        path: "#/orders",
      },
      {
        name: "accounts",
        neededPermissions: ["read:user-account.portalUsers"],
        path: "#/accounts",
      },
      {
        name: "bkt",
        neededPermissions: [],
        path: "#/bkt",
      },
    ],
  },
  {
    name: "@apetito/mini-basket",
    requiresLogin: true,

    neededPermissions: ["read:basket.any"],
  },
  {
    name: "@apetito/basket",
    requiresLogin: true,
    path: "basket",

    neededPermissions: ["read:basket.any"],
  },
  {
    name: "@apetito/navigation",
    requiresLogin: true,
    neededPermissions: [],
  },
  {
    name: "@apetito/faq",
    requiresLogin: true,
    path: "help",
    neededPermissions: [],
  },
  {
    name: "@apetito/product-catalog",
    requiresLogin: true,
    path: "products",
    entryPoints: [
      {
        name: "food",
        neededPermissions: ["read:product-catalog.food"],
        path: "#/food",
      },
      {
        name: "material",
        neededPermissions: ["read:product-catalog.material"],
        path: "#/materials",
      },
    ],
  },
  {
    name: "@apetito/menuservicemanager",
    requiresLogin: true,
    path: "menuservicemanager",
    neededPermissions: [
      // "read:menuservice-manager",
      "read:menuservice-alacarte",
    ],
  },
  {
    name: "@apetito/mylunch",
    requiresLogin: true,
    path: "mylunch",
    neededPermissions: ["read:mylunch"],
  },
  {
    name: "@apetito/application-guard",
    requiresLogin: true,
    paths: ["mylunch", "menuservicemanager"],
    neededPermissions: [
      "read:mylunch",
      // "read:menuservice-manager",
      "read:menuservice-alacarte",
    ],
  },
  {
    name: "@apetito/menuplanner-dashboard",
    requiresLogin: true,
    path: "menuplanner-dashboard",
    neededPermissions: ["read:menuplanner-dashboard", "read:menuservice-manager"],
  },
  {
    name: "@apetito/ibssc",
    requiresLogin: true,
    neededPermissions: ["read:ibssc"],
  },
  {
    name: "@apetito/downloads",
    requiresLogin: true,
    path: "downloads",
    neededPermissions: ["read:downloads"],
  },
  {
    name: "@apetito/seminars",
    requiresLogin: true,
    neededPermissions: ["read:seminars"],
  },
  {
    name: "@apetito/notifications",
    requiresLogin: true,
    neededPermissions: [],
  },
  {
    name: "@apetito/contact-form",
    requiresLogin: true,
    path: "contact",
    neededPermissions: [],
  },
];

export default applications;
