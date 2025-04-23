using Application.Helpers.Security;
using Core.DTO;
using Core.Entity;
using Core.Response.GenericResults;

namespace Application.Service
{
    public interface IAuthService
    {
        Task<IDataResult<UserDTO>> Register(UserForRegisterDto userForRegisterDto, string password);
        Task<IDataResult<User>> Login(UserForLoginDto userForLoginDto);
        Task<IDataResult<User>> CheckUserLogin(string userTaxId, string role);
        Task<IResult> UserExists(string userTaxId);
        Task<IDataResult<AccessToken>> CreateAccessToken(User user);
    }
}
