using Core.DTO;
using Core.Entity;

namespace Core.Interface
{
    public interface IRegionRepository : IGenericRepository<Region>
    {
        //Task<List<Region>> CheckIfPointInAnyRegion(LocationDto locationDto);
        // Eğer Region’a özel metotlar varsa burada tanımlarsın
    }
}
