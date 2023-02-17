namespace apetito.meinapetito.Portal.Contracts.Root.Users.Claims;

public class UserClaim
{

    public UserClaim()
    {
        Type = string.Empty;
        Value = string.Empty;
    }

    public UserClaim(string type, string value)
    {
        Type = type;
        Value = value;
    }

    public string Type { get; set; }
    public string Value { get; set; }

    public override bool Equals(object? obj)
    {
        if (obj is UserClaim userClaim)
        {
            return userClaim.Type == Type && userClaim.Value == Value;
        }

        return false;
    }

    public override int GetHashCode()
    {
        return string.Join( "=",Type, Value).GetHashCode();
    }
}