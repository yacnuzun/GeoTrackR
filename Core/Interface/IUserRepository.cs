using Core.Entity;

namespace Core.Interface
{
    public interface IUserRepository : IGenericRepository<User>
    {
        List<OperationClaim> GetClaims(User user);
        // Eğer User’a özel metotlar varsa burada tanımlarsın
    }


    public interface IUserOperationClaimRepository : IGenericRepository<UserOperationClaim>
    {
        // Eğer User’a özel metotlar varsa burada tanımlarsın
    }
}
