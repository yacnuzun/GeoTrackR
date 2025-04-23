using Core.Interface;
using System.IdentityModel.Tokens.Jwt;

namespace Core.DTO
{
    public class UserForRegisterDto : IDTO
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public LocationDto Location { get; set; }
    }
}
