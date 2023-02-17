using System.Text;
using System.Security.Cryptography;
using apetito.meinapetito.Portal.Contracts.Root.Authentication.UserAccessToken;
using Microsoft.Extensions.Options;

namespace apetito.meinapetito.Portal.Application.Root.Authentication.UserAccessTokens.IbsscToken
{
    public class IbsscTokenFactory : IUserAccessIbsscTokenFactory
    {
        private string _secret;
        private string _email = string.Empty;

        public IbsscTokenFactory(IOptions<IbsscTokenOptions> options)
        {
            _secret = options.Value.Secret;
        }

        public UserAccessIbsscTokenDto Create()
        {
            return new UserAccessIbsscTokenDto()
            {
                Token = CreateEncodedToken()
            };
        }

        public IUserAccessIbsscTokenFactory WithEmail(string email)
        {
            _email = email;
            return this;
        }

        private string CreateEncodedToken()
        {
            var md5Provider = MD5.Create();

            var dateString = string.Concat(DateTime.Now.Year.ToString(), DateTime.Now.Month.ToString().PadLeft(2, '0'), DateTime.Now.Day.ToString().PadLeft(2, '0'));
            var textToHash = Encoding.Default.GetBytes(string.Concat(_email, _secret, dateString));
            var result = md5Provider.ComputeHash(textToHash);
            
            return BitConverter.ToString(result).Replace("-", string.Empty);
        }
    }
}
