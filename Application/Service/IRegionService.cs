using Core.DTO;

namespace Application.Service
{
    public interface IRegionService
    {
        Task<IEnumerable<RegionDTO>> GetAllAsync();
        Task<RegionDTO> GetByIdAsync(int id);
        Task<RegionDTO> CreateAsync(RegionDTO regionDto);
        Task<bool> DeleteAsync(int id);
    }
}
