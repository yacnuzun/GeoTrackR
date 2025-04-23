using Core.DTO;
using Core.Entity;

namespace Application.Service
{
    public interface IRegionService
    {
        Task<IEnumerable<RegionDTO>> GetAllAsync();
        Task<RegionDTO> GetByIdAsync(int id);
        Task<RegionDTO> CreateAsync(RegionDTO regionDto);
        Task<bool> DeleteAsync(int id);
        //Task<List<Region>> CheckIfPointInAnyRegion(LocationDto locationDto);
    }
}
