using Microsoft.EntityFrameworkCore;

namespace TelemetryCar.Data
{
    public class TelemetryCarContext : DbContext
    {
        public TelemetryCarContext(DbContextOptions<TelemetryCarContext> options)
            : base(options)
        {
        }

        public DbSet<TelemetryCar.Model.CarModel> CarModel { get; set; }

        public DbSet<TelemetryCar.Model.TelemetryModel> TelemetryModel { get; set; }
    }
}