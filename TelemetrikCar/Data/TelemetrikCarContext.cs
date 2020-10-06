using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TelemetrikCar.Model;

namespace TelemetrikCar.Data
{
    public class TelemetrikCarContext : DbContext
    {
        public TelemetrikCarContext (DbContextOptions<TelemetrikCarContext> options)
            : base(options)
        {
        }

        public DbSet<TelemetrikCar.Model.Telemetrik> Telemetrik { get; set; }
    }
}
