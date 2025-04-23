using Core.Interface;
using NetTopologySuite.Geometries;

namespace Core.Entity
{
    public class Region:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        // Coğrafi alan
        public Polygon Polygon { get; set; } // PostGIS Geometry türü
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

}
