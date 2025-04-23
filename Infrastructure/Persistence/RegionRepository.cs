using Core.DTO;
using Core.Entity;
using Core.Interface;
using Infrastructure.EfCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using NetTopologySuite.Geometries;

namespace Infrastructure.Persistence
{
    public class RegionRepository : GenericRepository<Region>, IRegionRepository
    {
        private readonly ApplicationDbContext context;
        private readonly GeometryFactory _geometryFactory;
        public RegionRepository(ApplicationDbContext context, GeometryFactory geometryFactory) : base(context)
        {
            this.context = context;
            _geometryFactory = geometryFactory;
        }

        //public async Task<List<Region>> CheckIfPointInAnyRegion(LocationDto locationDto)
        //{
        //    var point = _geometryFactory.CreatePoint(new Coordinate(locationDto.Longitude, locationDto.Latitude));
        //    point.SRID = 4326;
        //    return await context.Regions
        //        .Where(r => Microsoft.EntityFrameworkCore.EF.Functions.Contains(r.Polygon, point))
        //        .ToListAsync();
        //}
        // Region’a özel sorgular burada yazılabilir.
    }

}
