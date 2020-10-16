using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TelemetrikCar.Model
{
    public class Telemetrik
    {
        [Key]
        public int IdTel { get; set; }
        public int? idCar { get; set; }
        public Car Car { get; set; }
        public double Latitude{ get; set; }
        public double Longitude{ get; set; }
        public double Speed{ get; set; }
        public double Capacity{ get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }
        [DataType(DataType.Date)]
        public DateTime ModifiedAt { get; set; }
    }
}
