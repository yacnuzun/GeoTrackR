using Core.Entity;
using Core.Interface;
using Infrastructure.EfCore;

namespace Infrastructure.Persistence
{
    public class RegionRepository : GenericRepository<Region>, IRegionRepository
    {
        public RegionRepository(ApplicationDbContext context) : base(context)
        {
        }

        // Region’a özel sorgular burada yazılabilir.
    }

}
