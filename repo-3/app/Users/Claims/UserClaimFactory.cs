using apetito.meinapetito.Portal.Contracts.Bkts.Enums;
using apetito.meinapetito.Portal.Contracts.Bkts.Models;
using apetito.meinapetito.Portal.Contracts.Root.Users.Claims;

namespace apetito.meinapetito.Portal.Application.Root.Users.Claims;

public static class UserClaimFactory
{
    private const string UserStatusApplicant = "Applicant";
    private const string UserStatusCustomerAdmin = "CustomerAdmin";
    private const string UserStatusCustomer = "Customer";

    private const string UserRoleAdministrator = "Administrator";
    private const string UserRoleOrderer = "Orderer";
    private const string UserRoleBkt = "bkt";
    
    private const string ContactPortalNka = "nka";
    private const string ContactPortalNkr = "nkr";
    private const string ContactPortalBka = "bka";
    private const string ContactPortalMaa = "maa";

    private const string UserEmailClaim = "meinapetito.useremail";
    private const string CustomerNumberClaim = "meinapetito.customernumber";
    private const string OrderSystemClaim = "meinapetito.ordersystem";
    private const string StatusClaim = "meinapetito.status";
    private const string PortalUserRoleClaim = "meinapetito.portaluserrole";
    private const string RoleClaim = "meinapetito.role";
    private const string BktBillingTypeClaim = "meinapetito.bkt.billingtype";
    private const string BktBillingTypeClaimMonthly = "monthly";
    private const string BktBillingTypeClaimDaily = "daily";

    private static UserClaim UserEmail(string value) => new UserClaim(UserEmailClaim, value);
    private static UserClaim CustomerNumber(int value) => new UserClaim(CustomerNumberClaim, value.ToString());
    private static UserClaim OrderSystem(string value) => new UserClaim(OrderSystemClaim, value);
    private static UserClaim Status(string value) => new UserClaim(StatusClaim, value);
    private static UserClaim StatusApplicant() => new UserClaim(StatusClaim, UserStatusApplicant);
    private static UserClaim PortalUserRole(string value) => new UserClaim(PortalUserRoleClaim, value);
    private static UserClaim Role(string value) => new UserClaim(RoleClaim, value);

    public static UserClaim GetPortalUserRoleClaim(this IEnumerable<UserClaim> claims)
    {
        return claims.FirstOrDefault(c => c.Type == PortalUserRoleClaim) ?? PortalUserRole(UserRoleOrderer);
    }
    
    public static IEnumerable<UserClaim> DeriveApplicantClaims()
    {
        yield return StatusApplicant();
    }
    
    public static IEnumerable<UserClaim> DeriveClaimsFromEmail(string email)
    {
        yield return UserEmail(email);
    }

    public static IEnumerable<UserClaim> DeriveClaimsFromRoles(IEnumerable<string> roles)
    {
        return roles.Select(r => Role(r));
    }

    public static UserClaim DeriveClaimFromBktBillings()
    {
        return new UserClaim(RoleClaim, UserRoleBkt);
    }

    public static UserClaim DeriveClaimFromBktBillingTypes(BillingType billingType)
        => billingType switch
        {
            BillingType.ImmediateBilling => new UserClaim(BktBillingTypeClaim, BktBillingTypeClaimDaily),
            BillingType.BillingToMonthmid => new UserClaim(BktBillingTypeClaim,BktBillingTypeClaimMonthly),
            _ => throw new ArgumentOutOfRangeException(nameof(billingType), billingType, null)
        };

    public static IEnumerable<UserClaim> DeriveClaimsFromCustomerNumber(int customerNumber)
    {
        yield return CustomerNumber(customerNumber);
    }
    
    public static IEnumerable<UserClaim> DeriveClaimsFromOrderSystem(string orderSystem)
    {
        yield return OrderSystem(GetUserOrderSystem(orderSystem));
    }
    
    public static IEnumerable<UserClaim> DeriveClaimsFromContactPortal(string? contactPortal)
    {
        yield return Status(GetUserStatusBasedOnContactPortal(contactPortal));
        yield return PortalUserRole(GetPortalUserRoleBasedOnContactPortal(contactPortal));
    }
    
    public static IEnumerable<UserClaim> DeriveClaimsFromAdditionalRoles(IEnumerable<string> additionalRoles)
    {
        return additionalRoles.Select(r => Role(r));
    }

    public static string GetPortalUserRoleBasedOnContactPortal(string? contactPortal)
    {
        return GetUserRoleBaseOnUserStatus(GetUserStatusBasedOnContactPortal(contactPortal));
    }
    
    public static string GetContactPortalBasedOnUserRole(string? userRole)
    {
        return userRole.Equals(UserRoleAdministrator, StringComparison.InvariantCultureIgnoreCase) ? ContactPortalNka : string.Empty;
    }

    private static string GetUserStatusBasedOnContactPortal(string? contactPortal)
    {
        switch (contactPortal?.ToLower() ?? string.Empty)
        {
            case ContactPortalNka:
            case ContactPortalNkr:
            case ContactPortalBka:
            case ContactPortalMaa:
                return UserStatusCustomerAdmin;

            default:
                return UserStatusCustomer;
        }
    }

    private static string GetUserRoleBaseOnUserStatus(string status) =>
        status switch
        {
            UserStatusCustomerAdmin => UserRoleAdministrator,
            _ => UserRoleOrderer
        };
    
    private static string GetUserOrderSystem(string orderSystem)
    {
        if (string.IsNullOrWhiteSpace(orderSystem))
            return "MAD";

        return orderSystem;
    }

}