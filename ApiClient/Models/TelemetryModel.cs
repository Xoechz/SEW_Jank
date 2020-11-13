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

        /// <summary>
        /// In meters per second.
        /// </summary>
        public double Speed { get; set; }

        /// <summary>
        /// Battery capacity between 0 and 100 in percent.
        /// </summary>
        public double Capacity { get; set; }

        /// <summary>
        /// Engine load between 0 and 100 in percent.
        /// </summary>
        public double Throttle { get; set; }

        /// <summary>
        /// Timestamp of when telemetry data was captured.
        /// </summary>
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public Car Car { get; set; }
    }
}
