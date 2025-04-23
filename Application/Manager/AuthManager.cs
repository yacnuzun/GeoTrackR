using Application.Helpers.Security;
using Application.Service;
using Core.Constant;
using Core.DTO;
using Core.Entity;
using Core.Response.GenericResults;

namespace Application.Manager
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
        public async Task<IDataResult<UserDTO>> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Id = userForRegisterDto.Id,
                Name = userForRegisterDto.UserName,
                Email = userForRegisterDto.Email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true,
                CreatedAt = DateTime.UtcNow,
                
            };
            var result = await _userService.CreateUserAsync(user);

            return new SuccessDataResult<UserDTO>(new UserDTO { Id=user.Id,Email=user.Email,Name=user.Name }, Messages.UserRegistered);
        }
        public async Task<IDataResult<User>> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = await _userService.GetUserByIdAsync(userForLoginDto.UserTaxID);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public async Task<IResult> UserExists(string userTaxId)
        {
            if (_userService.GetUserByIdAsync(userTaxId) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccesResult();
        }

        public async Task<IDataResult<AccessToken>> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claims);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public async Task<IDataResult<User>> CheckUserLogin(string userTaxId, string role)
        {
            var userToCheck = await _userService.GetUserByIdAsync(userTaxId);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            var listclaims = _userService.GetClaims(userToCheck);

            if (!listclaims.Exists(l => l.Name.ToLower().Contains(role.ToLower())))
            {
                return new ErrorDataResult<User>(Messages.AccessWarning);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }
    }

}
