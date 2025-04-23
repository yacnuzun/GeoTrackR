using Application.Service;
using Core.DTO;
using Core.Entity;
using Core.Interface;
using NetTopologySuite.Geometries;

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
                Name = regionDto.Name,
                CreatedAt = DateTime.UtcNow,
                Description = regionDto.Description,
                Polygon = new NetTopologySuite.Geometries.Polygon(new NetTopologySuite.Geometries.LinearRing(regionDto.Cordinates.Select(c => new Coordinate(c.Longitude, c.Latitude)).ToArray())) { SRID=4326}
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

        //public async Task<List<Region>> CheckIfPointInAnyRegion(LocationDto locationDto)
        //{
        //    var point = new Point(locationDto.Longitude, locationDto.Latitude) { SRID = 4326 };

        //    return await _regionRepository.CheckIfPointInAnyRegion(locationDto);
        //}
    }

}
