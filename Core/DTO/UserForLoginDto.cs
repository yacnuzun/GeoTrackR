using Core.Interface;

namespace Core.DTO
{
    public class UserForLoginDto : IDTO
    {
        public string UserName { get; set; }
        public string UserTaxID { get; set; }
        public string Password { get; set; }
    }
}
