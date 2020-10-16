using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TelemetryCar.Model;

namespace TelemetryCar.Data
{
    public class TelemetryCarContext : DbContext
    {
        public TelemetryCarContext (DbContextOptions<TelemetryCarContext> options)
            : base(options)
        {
        }

        public DbSet<TelemetryCar.Model.CarModel> CarModel { get; set; }

        public DbSet<TelemetryCar.Model.TelemetryModel> TelemetryModel { get; set; }
    }
}
