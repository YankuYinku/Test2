USE [AuthorizationDb];


WITH ApplicationsTable (Id, Name)
AS
(
              SELECT '913276de-19bf-4985-9878-0748ba12a797', '@apetito/dashboard'
    UNION ALL SELECT '47908a6c-dace-4c12-bada-65116b532ea0', '@apetito/user-account'
    UNION ALL SELECT '03d05918-87e0-4791-b8b8-9f15f1381013', '@apetito/mini-basket'
    UNION ALL SELECT '66aead48-6d82-4073-ad44-3abe9c8423d4', '@apetito/basket'
    UNION ALL SELECT 'b3a0bb53-37be-4cb5-8174-612038e93c19', '@apetito/navigation'
    UNION ALL SELECT 'bca791cc-e54a-42c2-b67a-3ed463ceeab6', '@apetito/product-catalog'
    UNION ALL SELECT '08156db8-8427-41c9-b8c4-8b69c73c9106', '@apetito/menuplanner-dashboard'
    UNION ALL SELECT '59fe6d34-446c-4927-b02e-cd782c53f770', '@apetito/ibssc'
    UNION ALL SELECT 'c3d6efa0-bf11-4915-acd8-f6fe9fa9e53f', '@apetito/downloads'
    UNION ALL SELECT '28e719e3-01d8-4545-86e2-7437dc1db5b1', '@apetito/seminars'
    UNION ALL SELECT '51f79cb3-4946-49c2-96b3-3b04f9ab34c9', '@apetito/menuservice-alacarte'
    UNION ALL SELECT '92539766-67ba-4701-b056-5384ae49da21', '@apetito/menuservice-manager'
    UNION ALL SELECT '0b6cccf9-cf4b-4732-bbde-e61015c1af9a', '@apetito/mylunch'
)
INSERT INTO Applications (Id, Name)
    SELECT Id, Name
    FROM ApplicationsTable
    WHERE Id NOT IN (SELECT Id FROM Applications);

WITH PermissionsTable (Id, Name, Description)
AS
(
              SELECT '3a9cf803-18c1-43a8-8198-52da5e425a6f', 'read:dashboard.standard', ''
    UNION ALL SELECT '5b35b36f-967a-4dbe-8f02-be4a8c413d1e', 'read:dashboard.ibssc', ''
    UNION ALL SELECT '3194a1e0-2b34-4a3c-9ead-6da7c56dd6e1', 'read:dashboard.applicant', ''

    UNION ALL SELECT '9d51b3f1-d7c7-4627-89f5-191803a5aa22', 'read:basket.all', ''
    UNION ALL SELECT '03cad9e4-88ad-47df-993c-7f6904e2a841', 'read:basket.any', ''

    UNION ALL SELECT '83ef1e53-a577-49d4-be8b-620d60f15a99', 'read:product-catalog.food', ''
    UNION ALL SELECT '0f96581c-b4ac-425f-9dd7-3186718bc00a', 'read:product-catalog.material', ''
    UNION ALL SELECT 'afebca67-de1d-488b-bb8f-0c8aa0ea4b92', 'create:product-catalog.food.basketItem', ''
    UNION ALL SELECT 'e83e24a7-d8ca-4bff-9192-7392815f4dd0', 'create:product-catalog.material.basketItem', ''

    UNION ALL SELECT '9771e7a1-90fa-4082-847c-9b394d04b266', 'read:user-account.bkt', ''
    UNION ALL SELECT '2e96b237-bdc7-4363-a655-9c318cea6fa6', 'create:user-account.bkt', ''

    UNION ALL SELECT 'c33a21fd-accc-452d-a8a0-fdf8d93e7c25', 'read:user-account.bkt.billing.monthly', ''
    UNION ALL SELECT 'c431f1d4-9362-47d3-a24b-8e09894e4072', 'create:user-account.bkt.billing.monthly', ''
    UNION ALL SELECT '56c3fac3-17ec-4e7f-97fb-389eccc9ecc9', 'read:user-account.bkt.billing.daily', ''
    UNION ALL SELECT '343412a9-540d-4602-905a-0907c7c0f998', 'create:user-account.bkt.billing.daily', ''
              
    UNION ALL SELECT 'c0d8d51c-c3f6-4235-90f5-0a17f3d8c40a', 'read:user-account.portalUsers', ''
    UNION ALL SELECT 'fd47cb1a-6e50-4366-ad24-6423e6ac02a9', 'create:user-account.portalUsers', ''
    UNION ALL SELECT '96e50565-52fa-431e-83fa-82c18566053f', 'read:user-account.company', ''
    UNION ALL SELECT '3f2b7f06-caac-4fa5-b7db-d6066d8317fb', 'create:user-account.company', ''
    UNION ALL SELECT '3eac4c75-f0c6-49fc-a9ce-732f82d6d0ce', 'read:user-account.orderHistory', ''
    UNION ALL SELECT '5e237317-460a-4974-abe5-979a648ade34', 'create:user-account.orderHistory', ''
    UNION ALL SELECT '402da90b-707a-4b77-9be6-a3e40de0cd97', 'read:user-account.customerAccount', ''
    UNION ALL SELECT 'a6fc0db2-dd84-4179-a39b-f331f034b31d', 'create:user-account.customerAccount', ''
              
    UNION ALL SELECT '80648c52-acef-4e79-849a-276305b11ab0', 'read:menuplanner-dashboard', ''
    UNION ALL SELECT '302c1447-3760-47a6-aaa2-9195b15e914f', 'read:ibssc', ''
    UNION ALL SELECT '5d762749-6e7c-49c3-872c-919e01c63e23', 'read:downloads', ''
    UNION ALL SELECT '0060cd72-7a84-4e82-b053-13cad9e9e49e', 'read:seminars', ''

    UNION ALL SELECT '642d69cc-0e58-43bb-9c1e-e964f4e60834', 'read:menuservice-alacarte', ''
    UNION ALL SELECT '6b6dc100-297b-4f0e-a6f6-a9068fdfbde2', 'read:menuservice-manager', ''
    UNION ALL SELECT '9900d687-f1c4-4e63-8105-dc9d0654a5a6', 'read:mylunch', ''
)
INSERT INTO Permissions (Id, Name, Description)
    SELECT Id, Name, Description
    FROM PermissionsTable
    WHERE Id NOT IN (SELECT Id FROM Permissions);


WITH RolesTable (Id, ApplicationName, Name, [Description], IsDefault)
AS 
(
              SELECT '8127c4e1-8ba9-47d2-86f9-282600fcaf60', '@apetito/dashboard', 'reader:dashboard.standard', '', 0
    UNION ALL SELECT '1d32ef75-b0d3-457e-be84-8e9731d78379', '@apetito/dashboard', 'reader:dashboard.applicant', '', 0
    UNION ALL SELECT '52b28789-5284-4475-bfab-11c030d3e319', '@apetito/dashboard', 'reader:dashboard.ibssc', '', 0

    UNION ALL SELECT '121c225a-65ec-49ea-b9c1-567aed927020', '@apetito/basket', 'reader:basket', '', 0
    
    UNION ALL SELECT '42fe44e3-4941-476f-bef5-3f6bae423b64', '@apetito/product-catalog', 'reader:product-catalog', '', 0
    UNION ALL SELECT '0ce14980-110e-43ba-a4c8-f60d014d4e89', '@apetito/product-catalog', 'reader:product-catalog.material', '', 0
    UNION ALL SELECT '29e7614e-4f41-4b69-b395-0105dde7773a', '@apetito/product-catalog', 'contributor:product-catalog', '', 0
    UNION ALL SELECT 'b796c562-cc3a-457a-8d8d-906cc7531aa4', '@apetito/product-catalog', 'contributor:product-catalog.material', '', 0

    UNION ALL SELECT '4178dc2c-be6d-42d0-a52f-f78312dd7ed0', '@apetito/user-account', 'reader:user-account.bkt', '', 0
    UNION ALL SELECT 'a3484113-7304-49c8-9d68-438d7fc33f88', '@apetito/user-account', 'contributor:user-account.bkt', '', 0

    UNION ALL SELECT '107582ec-1265-4a62-babc-c41fc3b6990e', '@apetito/user-account', 'reader:user-account.bkt.billing.monthly', '', 0
    UNION ALL SELECT 'd33de535-ed66-4301-ac6e-d88586df252d', '@apetito/user-account', 'contributor:user-account.bkt.billing.monthly', '', 0

    UNION ALL SELECT '341b650b-00c9-4e9e-b6bd-9f6a95484e10', '@apetito/user-account', 'reader:user-account.bkt.billing.daily', '', 0
    UNION ALL SELECT '43dd5dac-3860-403b-8169-97dbc6b28756', '@apetito/user-account', 'contributor:user-account.bkt.billing.daily', '', 0
              
    UNION ALL SELECT '11b59f74-b22c-4251-a917-491c2e0cc932', '@apetito/user-account', 'reader:user-account.portalUsers', '', 0
    UNION ALL SELECT 'f9241573-5777-4bc9-9a90-645baf520d91', '@apetito/user-account', 'contributor:user-account.portalUsers', '', 0
              
    UNION ALL SELECT '514ab968-d884-46b9-b119-020cab9aeeb0', '@apetito/user-account', 'reader:user-account.company', '', 0
    UNION ALL SELECT '0fc3c0fa-222a-427f-a8ef-a5fd85f686f0', '@apetito/user-account', 'contributor:user-account.company', '', 0

    UNION ALL SELECT 'b66a0e2b-5e06-4548-9e72-0fac5e75bd33', '@apetito/user-account', 'reader:user-account.orderHistory', '', 0
    UNION ALL SELECT '296fe836-cc0b-408f-ae6a-201fa62339a7', '@apetito/user-account', 'contributor:user-account.orderHistory', '', 0

    UNION ALL SELECT '37646bb0-1a59-416a-8b6b-6024bcfbf817', '@apetito/user-account', 'reader:user-account.customerAccount', '', 0
    UNION ALL SELECT '6b2a6a7f-ace4-4aa9-b74a-c10525059a15', '@apetito/user-account', 'contributor:user-account.customerAccount', '', 0
              
    UNION ALL SELECT '025b2cb5-0315-4a2d-bb2c-48a0719942f1', '@apetito/menuplanner-dashboard', 'reader:menuplanner-dashboard', '', 0
    
    UNION ALL SELECT 'a4efafe2-496d-4b56-9034-32bf683aaf5f', '@apetito/ibssc', 'reader:ibssc', '', 0

    UNION ALL SELECT 'c8bc3755-cfd5-490c-8028-836b7158f3b1', '@apetito/downloads', 'reader:downloads', '', 0
    
    UNION ALL SELECT '9706c844-dc30-402c-b081-e46aaf3e08b9', '@apetito/seminars', 'reader:seminars', '', 0
              
    UNION ALL SELECT '6c97f9b0-5d4c-4b93-97c4-21ad035e3924', '@apetito/menuservice-alacarte', 'reader:menuservice-alacarte', '', 0
              
    UNION ALL SELECT 'a92c39f8-dac4-439b-a07a-1b1489ebb621', '@apetito/menuservice-manager', 'reader:menuservice-manager', '', 0
              
    UNION ALL SELECT '5c7d194f-d949-4e4b-9857-6eb093bfc361', '@apetito/mylunch', 'reader:mylunch', '', 0
)
INSERT INTO Roles (Id, ApplicationName, Name, [Description], IsDefault)
    SELECT Id, ApplicationName, Name, [Description], IsDefault
    FROM RolesTable
    WHERE Id NOT IN (SELECT Id FROM Roles);


WITH RolePermissionsTable (RoleId, PermissionId)
AS
(

              SELECT (SELECT Id FROM Roles WHERE ApplicationName = '@apetito/dashboard' AND Name = 'reader:dashboard.standard'), (SELECT Id FROM Permissions WHERE Name = 'read:dashboard.standard')
    UNION ALL SELECT (SELECT Id FROM Roles WHERE ApplicationName = '@apetito/dashboard' AND Name = 'reader:dashboard.ibssc'), (SELECT Id FROM Permissions WHERE Name = 'read:dashboard.ibssc')
    UNION ALL SELECT (SELECT Id FROM Roles WHERE ApplicationName = '@apetito/dashboard' AND Name = 'reader:dashboard.applicant'), (SELECT Id FROM Permissions WHERE Name = 'read:dashboard.applicant')

    UNION ALL SELECT Roles.Id, Permissions.Id FROM Roles, Permissions WHERE ApplicationName = '@apetito/basket' AND Roles.Name = 'reader:basket' AND Permissions.Name = 'read:basket.any'

    UNION ALL SELECT Roles.Id, Permissions.Id FROM Roles, Permissions WHERE ApplicationName = '@apetito/product-catalog' AND Roles.Name = 'reader:product-catalog' AND Permissions.Name LIKE 'read:product-catalog%'
    UNION ALL SELECT Roles.Id, Permissions.Id FROM Roles, Permissions WHERE ApplicationName = '@apetito/product-catalog' AND Roles.Name = 'contributor:product-catalog' AND CHARINDEX('delete', Permissions.Name) != 1 AND Permissions.Name LIKE '%:product-catalog%'
    UNION ALL SELECT (SELECT Id FROM Roles WHERE ApplicationName = '@apetito/product-catalog' AND Name = 'reader:product-catalog.material'), (SELECT Id FROM Permissions WHERE Name = 'read:product-catalog.material')
    UNION ALL SELECT Roles.Id, Permissions.Id FROM Roles, Permissions WHERE ApplicationName = '@apetito/product-catalog' AND Roles.Name = 'contributor:product-catalog.material' AND CHARINDEX('delete', Permissions.Name) != 1 AND Permissions.Name LIKE '%:product-catalog.material%'

    UNION ALL SELECT Roles.Id, Permissions.Id FROM Roles, Permissions WHERE ApplicationName = '@apetito/user-account' AND Roles.Name = 'contributor:user-account.bkt' AND Permissions.Name IN ('read:user-account.bkt', 'create:user-account.bkt')
    UNION ALL SELECT Roles.Id, Permissions.Id FROM Roles, Permissions WHERE ApplicationName = '@apetito/user-account' AND Roles.Name = 'reader:user-account.bkt' AND Permissions.Name IN ('read:user-account.bkt')

    UNION ALL SELECT Roles.Id, Permissions.Id FROM Roles, Permissions WHERE ApplicationName = '@apetito/user-account' AND Roles.Name = 'contributor:user-account.bkt.billing.monthly' AND Permissions.Name IN ('read:user-account.bkt.billing.monthly', 'create:user-account.bkt.billing.monthly')
    UNION ALL SELECT Roles.Id, Permissions.Id FROM Roles, Permissions WHERE ApplicationName = '@apetito/user-account' AND Roles.Name = 'reader:user-account.bkt.billing.monthly' AND Permissions.Name IN ('read:user-account.bkt.billing.monthly')

    UNION ALL SELECT Roles.Id, Permissions.Id FROM Roles, Permissions WHERE ApplicationName = '@apetito/user-account' AND Roles.Name = 'contributor:user-account.bkt.billing.daily' AND Permissions.Name IN ('read:user-account.bkt.billing.daily', 'create:user-account.bkt.billing.daily')
    UNION ALL SELECT Roles.Id, Permissions.Id FROM Roles, Permissions WHERE ApplicationName = '@apetito/user-account' AND Roles.Name = 'reader:user-account.bkt.billing.daily' AND Permissions.Name IN ('read:user-account.bkt.billing.daily')


    UNION ALL SELECT Roles.Id, Permissions.Id FROM Roles, Permissions WHERE ApplicationName = '@apetito/user-account' AND Roles.Name = 'contributor:user-account.portalUsers' AND Permissions.Name IN ('read:user-account.portalUsers', 'create:user-account.portalUsers')
    UNION ALL SELECT Roles.Id, Permissions.Id FROM Roles, Permissions WHERE ApplicationName = '@apetito/user-account' AND Roles.Name = 'reader:user-account.portalUsers' AND Permissions.Name IN ('read:user-account.portalUsers')

    UNION ALL SELECT Roles.Id, Permissions.Id FROM Roles, Permissions WHERE ApplicationName = '@apetito/user-account' AND Roles.Name = 'contributor:user-account.company' AND Permissions.Name IN ('read:user-account.company', 'create:user-account.company')
    UNION ALL SELECT Roles.Id, Permissions.Id FROM Roles, Permissions WHERE ApplicationName = '@apetito/user-account' AND Roles.Name = 'reader:user-account.company' AND Permissions.Name IN ('read:user-account.company')

    UNION ALL SELECT Roles.Id, Permissions.Id FROM Roles, Permissions WHERE ApplicationName = '@apetito/user-account' AND Roles.Name = 'contributor:user-account.orderHistory' AND Permissions.Name IN ('read:user-account.orderHistory', 'create:user-account.orderHistory')
    UNION ALL SELECT Roles.Id, Permissions.Id FROM Roles, Permissions WHERE ApplicationName = '@apetito/user-account' AND Roles.Name = 'reader:user-account.orderHistory' AND Permissions.Name IN ('read:user-account.orderHistory')

    UNION ALL SELECT Roles.Id, Permissions.Id FROM Roles, Permissions WHERE ApplicationName = '@apetito/user-account' AND Roles.Name = 'contributor:user-account.customerAccount' AND Permissions.Name IN ('read:user-account.customerAccount', 'create:user-account.customerAccount')
    UNION ALL SELECT Roles.Id, Permissions.Id FROM Roles, Permissions WHERE ApplicationName = '@apetito/user-account' AND Roles.Name = 'reader:user-account.customerAccount' AND Permissions.Name IN ('read:user-account.customerAccount')
                                                                      
    UNION ALL SELECT (SELECT Id FROM Roles WHERE ApplicationName = '@apetito/menuplanner-dashboard' AND Name = 'reader:menuplanner-dashboard'), (SELECT Id FROM Permissions WHERE Name = 'read:menuplanner-dashboard')

    UNION ALL SELECT (SELECT Id FROM Roles WHERE ApplicationName = '@apetito/ibssc' AND Name = 'reader:ibssc'), (SELECT Id FROM Permissions WHERE Name = 'read:ibssc')
    
    UNION ALL SELECT (SELECT Id FROM Roles WHERE ApplicationName = '@apetito/downloads' AND Name = 'reader:downloads'), (SELECT Id FROM Permissions WHERE Name = 'read:downloads')
    
    UNION ALL SELECT (SELECT Id FROM Roles WHERE ApplicationName = '@apetito/seminars' AND Name = 'reader:seminars'), (SELECT Id FROM Permissions WHERE Name = 'read:seminars')
              
    UNION ALL SELECT (SELECT Id FROM Roles WHERE ApplicationName = '@apetito/menuservice-alacarte' AND Name = 'reader:menuservice-alacarte'), (SELECT Id FROM Permissions WHERE Name = 'read:menuservice-alacarte')
              
    UNION ALL SELECT (SELECT Id FROM Roles WHERE ApplicationName = '@apetito/menuservice-manager' AND Name = 'reader:menuservice-manager'), (SELECT Id FROM Permissions WHERE Name = 'read:menuservice-manager')
              
    UNION ALL SELECT (SELECT Id FROM Roles WHERE ApplicationName = '@apetito/mylunch' AND Name = 'reader:mylunch'), (SELECT Id FROM Permissions WHERE Name = 'read:mylunch')
)
-- DELETE FROM PermissionRole
-- WHERE EXISTS (SELECT PermissionsId, RolesId FROM RolePermissionsTable WHERE PermissionsId = PermissionId AND RolesId = RoleId );
INSERT INTO PermissionRole (PermissionsId, RolesId)
    SELECT rpt.PermissionId, rpt.RoleId
    FROM RolePermissionsTable rpt
    WHERE NOT EXISTS (SELECT PermissionsId, RolesId FROM PermissionRole WHERE PermissionsId = rpt.PermissionId AND RolesId = rpt.RoleId );



WITH RequiredClaimsTable (Id, [Type], [Value])
AS
(
              SELECT 'fb2bf020-a8b2-4143-9d30-7e829c17079e', 'meinapetito.status', 'Applicant'
    UNION ALL SELECT 'a56a7e4d-ea6d-460c-a833-91fff708bad1', 'meinapetito.status', 'Customer'
    UNION ALL SELECT '825d4e0b-2910-42ff-becf-a2706798c046', 'meinapetito.status', 'CustomerAdmin'

    UNION ALL SELECT 'a3ea0f76-3cfd-43ee-82f1-0e4fbabb94ef', 'meinapetito.ordersystem', 'MAD'
    UNION ALL SELECT 'b4522476-acbf-4146-8cd3-ed55ad619134', 'meinapetito.ordersystem', 'IB1'
    UNION ALL SELECT '6ff8c31f-3d27-4f6e-b43a-00b0adcb607a', 'meinapetito.ordersystem', 'MPL'
    UNION ALL SELECT '86c56834-a6b7-4d91-a7aa-e0c280e3163e', 'meinapetito.ordersystem', 'MSM'
    UNION ALL SELECT 'd95c098b-0d72-4e8f-9191-f1df27dfd8d4', 'meinapetito.ordersystem', 'MSA'
    UNION ALL SELECT 'c6aa7d10-9ac9-478f-9fda-e4bbb93afa12', 'meinapetito.ordersystem', 'MYL'

    UNION ALL SELECT 'd0092f82-572f-46ac-ab08-65f62574ecf6', 'meinapetito.role', 'forcemenuplanner'
    UNION ALL SELECT 'b6611315-6b23-4df8-bb49-77a094d9fa63', 'meinapetito.role', 'bkt'
    UNION ALL SELECT 'ea89e412-ae2f-41c4-b684-bce8cb70429a', 'meinapetito.bkt.billingtype', 'daily'
    UNION ALL SELECT 'c7d5a22b-66a3-47a5-9b50-267786df310f', 'meinapetito.bkt.billingtype', 'monthly'
    
    --UNION ALL SELECT '54e35e4d-b433-4cbc-8ff2-de77219a7b92', 'meinapetito.useremail', 'richlint@apebs.de'
)
-- DELETE FROM RequiredClaims
-- WHERE Id IN (SELECT Id FROM RequiredClaimsTable)
INSERT INTO RequiredClaims (Id, [Type], [Value])
    SELECT Id, [Type], [Value]
    FROM RequiredClaimsTable
    WHERE Id NOT IN (SELECT Id FROM RequiredClaims);

WITH RequiredClaimRoleTable (RequiredClaimId, RoleId)
AS
(
              SELECT (SELECT Id FROM RequiredClaims WHERE Type = 'meinapetito.status' AND [Value] = 'Applicant'), (SELECT Id FROM Roles WHERE ApplicationName = '@apetito/dashboard' AND Name = 'reader:dashboard.applicant' ) 
    UNION ALL SELECT rc.Id, r.Id FROM RequiredClaims rc, Roles r WHERE rc.[Type] = 'meinapetito.status' AND rc.Value = 'Customer'AND r.Name IN ('reader:basket', 'reader:downloads', 'reader:seminars', 'reader:user-account.company','reader:user-account.portalUsers','reader:user-account.orderHistory','reader:user-account.customerAccount')
    UNION ALL SELECT rc.Id, r.Id FROM RequiredClaims rc, Roles r WHERE rc.[Type] = 'meinapetito.status' AND rc.Value = 'CustomerAdmin'AND r.Name IN ('reader:basket','reader:downloads', 'reader:seminars','contributor:user-account.company','contributor:user-account.portalUsers','contributor:user-account.orderHistory','contributor:user-account.customerAccount')
    
    UNION ALL SELECT (SELECT Id FROM RequiredClaims WHERE Type = 'meinapetito.role' AND [Value] = 'forcemenuplanner'), (SELECT Id FROM Roles WHERE ApplicationName = '@apetito/menuplanner-dashboard' AND Name = 'reader:menuplanner-dashboard' )
    UNION ALL SELECT (SELECT Id FROM RequiredClaims WHERE Type = 'meinapetito.role' AND [Value] = 'bkt'), (SELECT Id FROM Roles WHERE ApplicationName = '@apetito/user-account' AND Name = 'contributor:user-account.bkt' )
                                                                                                                                             
    UNION ALL SELECT rc.Id, r.Id FROM RequiredClaims rc, Roles r WHERE rc.[Type] = 'meinapetito.ordersystem' AND rc.Value = 'MAD' AND r.Name IN ('reader:dashboard.standard', 'contributor:product-catalog', 'reader:menuplanner-dashboard')
    UNION ALL SELECT rc.Id, r.Id FROM RequiredClaims rc, Roles r WHERE rc.[Type] = 'meinapetito.ordersystem' AND rc.Value = 'MPL' AND r.Name IN ('reader:dashboard.standard', 'contributor:product-catalog', 'reader:menuplanner-dashboard')
    UNION ALL SELECT rc.Id, r.Id FROM RequiredClaims rc, Roles r WHERE rc.[Type] = 'meinapetito.ordersystem' AND rc.Value = 'MSM' AND r.Name IN ('reader:dashboard.standard', 'contributor:product-catalog', 'reader:menuplanner-dashboard', 'reader:menuservice-manager')
    UNION ALL SELECT rc.Id, r.Id FROM RequiredClaims rc, Roles r WHERE rc.[Type] = 'meinapetito.ordersystem' AND rc.Value = 'MSA' AND r.Name IN ('reader:dashboard.standard', 'contributor:product-catalog', 'reader:menuplanner-dashboard','reader:menuservice-alacarte')

    UNION ALL SELECT rc.Id, r.Id FROM RequiredClaims rc, Roles r WHERE rc.[Type] = 'meinapetito.ordersystem' AND rc.Value = 'MYL' AND r.Name IN ('reader:dashboard.standard', 'contributor:product-catalog','reader:mylunch')
    UNION ALL SELECT rc.Id, r.Id FROM RequiredClaims rc, Roles r WHERE rc.[Type] = 'meinapetito.ordersystem' AND rc.Value = 'IB1' AND r.Name IN ('reader:dashboard.ibssc', 'reader:ibssc', 'contributor:product-catalog.material')
    UNION ALL SELECT rc.Id, r.Id FROM RequiredClaims rc, Roles r WHERE rc.[Type] = 'meinapetito.bkt.billingtype' AND rc.Value = 'daily' AND r.Name IN ('reader:user-account.bkt.billing.daily','contributor:user-account.bkt.billing.daily')
    UNION ALL SELECT rc.Id, r.Id FROM RequiredClaims rc, Roles r WHERE rc.[Type] = 'meinapetito.bkt.billingtype' AND rc.Value = 'monthly' AND r.Name IN ('reader:user-account.bkt.billing.monthly','contributor:user-account.bkt.billing.monthly')

)
-- DELETE FROM RequiredClaimRole
-- WHERE EXISTS (SELECT RequiredClaimsId, RolesId FROM RequiredClaimRoleTable WHERE RequiredClaimsId = RequiredClaimId AND RolesId = RoleId  );
INSERT INTO RequiredClaimRole (RequiredClaimsId, RolesId)
    SELECT RequiredClaimId, RoleId
    FROM RequiredClaimRoleTable rcrt
    WHERE NOT EXISTS (SELECT RequiredClaimsId, RolesId FROM RequiredClaimRole WHERE RequiredClaimsId = rcrt.RequiredClaimId AND RolesId = rcrt.RoleId );


