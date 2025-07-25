using Amazon.Runtime.Internal;
using fbbn.API.DTOs;

namespace fbbn.API.Services
{
    public interface ITokenService
    {
        public string GenerateJwtToken();
        public string Login(LoginDTO request);
    }
}
