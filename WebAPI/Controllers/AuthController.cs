using Application.Helpers.Security;
using Application.Service;
using Core.Constant;
using Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        readonly IAuthService _authService;
        readonly ITokenHelper _tokenHelper;

        public AccountController(IAuthService authService, ITokenHelper tokenHelper)
        {
            _authService = authService;
            _tokenHelper = tokenHelper;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = await _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin.Message);
            }

            var result = await _authService.CreateAccessToken(userToLogin.Data);
            if (!result.Success)
            {
                return BadRequest(result.Message);
            }


            return Ok(result.Data);
        }

        [HttpPost("loginAcces")]
        [Authorize]
        public async Task<ActionResult> LoginAccess(UserForLoginAccessDto role)
        {
            var jwtToken = _tokenHelper.ValidateTokenGetClaims(HttpContext.Request.Headers.Authorization.ToString().Replace("Bearer ", ""));

            if (jwtToken is null)
            {
                return Ok(Messages.FailedProccess);
            }

            var result = await _authService.CheckUserLogin(jwtToken.Claims.FirstOrDefault(s => s.Type.Contains("nameidentifier")).Value, role.Role);

            if (!result.Success)
            {
                return Ok(Messages.FailedProccess);
            }

            JwtDto jwtDto = JwtDto.GetViewModel(jwtToken);

            return Ok(jwtDto);
        }
        [HttpPost("register")]
        public async Task<ActionResult> Register(UserForRegisterDto user)
        {
            //var jwtToken = _tokenHelper.ValidateTokenGetClaims(HttpContext.Request.Headers.Authorization.ToString().Replace("Bearer ", ""));

            //if (jwtToken is null)
            //{
            //    return Ok(Messages.FailedProccess);
            //}

            var result = await _authService.Register(user, user.Password);

            if (!result.Success)
            {
                return Ok(Messages.FailedProccess);
            }

            //JwtDto jwtDto = JwtDto.GetViewModel(jwtToken);

            return Ok(result.Message);
        }

    }

}
