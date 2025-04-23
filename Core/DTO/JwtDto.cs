using Core.Interface;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;

namespace Core.DTO
{
    public class JwtDto : IDTO
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "nameidentifier")]
        public string NameIdentifier { get; set; }
        [JsonProperty(PropertyName = "role")]
        public string Role { get; set; }
        public static JwtDto GetViewModel(JwtSecurityToken jwtSecurityToken)
        {
            return new JwtDto
            {
                Name = jwtSecurityToken.Claims.FirstOrDefault(s => s.Type.Contains("nameidentifier")).Value,
                NameIdentifier = jwtSecurityToken.Claims.FirstOrDefault(s => s.Type.Contains("name")).Value,
                Role = jwtSecurityToken.Claims.FirstOrDefault(s => s.Type.Contains("role")).Value
            };
        }
    }
}
