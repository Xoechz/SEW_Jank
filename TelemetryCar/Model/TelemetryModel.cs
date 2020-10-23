using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TelemetryCar.Model
{
    public class TelemetryModel
    {
        [Required] [Key] public int IdTel { get; set; }
        [Required] public int CarIdCar { get; set; }
        public CarModel Car { get; set; }
        [Required] public double Latitude { get; set; }
        [Required] public double Longitude { get; set; }
        [Required] public double Speed { get; set; }
        [Required] public double Capacity { get; set; }
        [Range(1, 100)] [Required] public double Throttle { get; set; }
        [DataType(DataType.DateTime)] public DateTime CreatedAt { get; set; }
        [DataType(DataType.DateTime)] public DateTime ModifiedAt { get; set; }
    }
}