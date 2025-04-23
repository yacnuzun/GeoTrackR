using Application.Service;
using Core.DTO;
using Core.Entity;
using Core.Interface;
using Core.Response.GenericResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Manager
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDTO>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return users.Select(u => new UserDTO
            {
                Id = u.Id,
                Name = u.Name,
                Email = u.Email
            });
        }

        public List<OperationClaim> GetClaims(User user)
        {
                var claims = _userRepository.GetClaims(user);
                return claims;

        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            var user = await _userRepository.GetByIdAsync(Convert.ToInt32(id));
            if (user == null) return null;
            return user;
        }

        //edit
        public async Task<IDataResult<User>> CreateUserAsync(User user)
        {
            try
            {
                

                await _userRepository.AddAsync(user);
                //await _userRepository.SaveChangesAsync();

                return new SuccessDataResult<User>(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.InnerException?.Message);
                return new ErrorDataResult<User>(user,ex.Message);
            }

        }


    }

}
