using Core.Entity;
using System.IdentityModel.Tokens.Jwt;

namespace Application.Helpers.Security
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
        JwtSecurityToken ValidateTokenGetClaims(string jwtToken);

    }
}
