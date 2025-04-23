using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.EfCore
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        // Bu metod design-time sırasında çağrılır.
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Burada DbContextOptions ayarlıyoruz
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            // Connection string’i burada manuel yazıyoruz (program.cs’deki gibi değil).
            optionsBuilder.UseNpgsql(
                "Host=localhost;Port=5433;Username=postgres;Password=123456;Database=postgis_34_sample;", // Burada kendi veritabanı bilgilerini gir
                o => o.UseNetTopologySuite() // Spatial verileri aktarmak için gerekli
            );

            // DbContextOptions ile yeni ApplicationDbContext örneği oluşturuyoruz
            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
