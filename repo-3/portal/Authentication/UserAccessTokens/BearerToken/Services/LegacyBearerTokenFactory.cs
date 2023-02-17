using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using apetito.meinapetito.Portal.Contracts.Root.Authentication.UserAccessToken;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace apetito.meinapetito.Portal.Application.Root.Authentication.UserAccessTokens.BearerToken.Services;

public class LegacyBearerTokenFactory : IUserAccessBearerTokenFactory
{
    private readonly string _secret;
    private readonly string _issuer;

    private readonly List<Claim> _claims = new();
    private string _audience = string.Empty;
    private int _durationInMinutes = 1;

    public LegacyBearerTokenFactory(IOptions<LegacyBearerTokenOptions> options)
    {
        _secret = options.Value.Secret;
        _issuer = options.Value.Issuer;
    }

    public UserAccessBearerTokenDto Create()
    {
        return new UserAccessBearerTokenDto()
        {
            Token = CreateSignedAndEncodedToken()
        };
    }

    public IUserAccessBearerTokenFactory WithClaims(IEnumerable<Claim> claims)
    {
        _claims.AddRange(claims);
        return this;
    }

    public IUserAccessBearerTokenFactory WithClaim(Claim claim)
    {
        _claims.Add(claim);
        return this;
    }

    public IUserAccessBearerTokenFactory WithDurationInMinutes(int minutes)
    {
        _durationInMinutes = minutes;
        return this;
    }

    public IUserAccessBearerTokenFactory WithAudience(string audience)
    {
        _audience = audience;
        return this;
    }

    private string CreateSignedAndEncodedToken()
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var plainToken = tokenHandler.CreateToken(CreateSecurityTokenDescriptor());
        var signedAndEncodedToken = tokenHandler.WriteToken(plainToken);
        return signedAndEncodedToken ?? string.Empty;
    }

    private SecurityTokenDescriptor CreateSecurityTokenDescriptor()
    {
        return new SecurityTokenDescriptor()
        {
            Audience = _audience,
            Issuer = _issuer,
            Subject = CreateClaimsIdentity(),
            SigningCredentials = GetSigningCredentials(),
            Expires = DateTime.Now.AddMinutes(_durationInMinutes)
        };
    }

    private ClaimsIdentity CreateClaimsIdentity() => new(_claims, "Custom");

    private SigningCredentials GetSigningCredentials()
    {
        var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(_secret));
        return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
    }

}