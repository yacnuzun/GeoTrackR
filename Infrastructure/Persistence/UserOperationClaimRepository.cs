using Core.Entity;
using Core.Interface;
using Infrastructure.EfCore;

namespace Infrastructure.Persistence
{
    public class UserOperationClaimRepository : GenericRepository<UserOperationClaim>, IUserOperationClaimRepository
    {
        public UserOperationClaimRepository(ApplicationDbContext context) : base(context)
        {
        }

    }

}
