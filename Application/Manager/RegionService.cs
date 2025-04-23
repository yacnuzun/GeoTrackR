using Application.Service;
using Core.DTO;
using Core.Entity;
using Core.Interface;

namespace Application.Manager
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _regionRepository;

        public RegionService(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public async Task<IEnumerable<RegionDTO>> GetAllAsync()
        {
            var regions = await _regionRepository.GetAllAsync();
            return regions.Select(r => new RegionDTO
            {
                Id = r.Id,
                Name = r.Name
            });
        }

        public async Task<RegionDTO> GetByIdAsync(int id)
        {
            var region = await _regionRepository.GetByIdAsync(id);
            if (region == null) return null;

            return new RegionDTO { Id = region.Id, Name = region.Name };
        }

        public async Task<RegionDTO> CreateAsync(RegionDTO regionDto)
        {
            var region = new Region
            {
                Name = regionDto.Name
            };

            await _regionRepository.AddAsync(region);
            return new RegionDTO { Id = region.Id, Name = region.Name };
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var region = await _regionRepository.GetByIdAsync(id);
            if (region == null) return false;

            await _regionRepository.Delete(region);
            return true;
        }
    }

}
