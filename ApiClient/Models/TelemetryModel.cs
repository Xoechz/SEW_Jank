using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiClient.Models
{
    public class TelemetryData
    {
        public int IdTel { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public double Speed { get; set; }

        public double Capacity { get; set; }

        public double Throttle { get; set; }

        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public Car Car { get; set; }
    }
}
