using Core.DTO;
using Core.Entity;
using Core.Response.GenericResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Service
{
    public interface IUserService
    {
        Task<IEnumerable<UserDTO>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(string id);
        List<OperationClaim> GetClaims(User user);
        Task<IDataResult<User>> CreateUserAsync(User user);
    }
}
