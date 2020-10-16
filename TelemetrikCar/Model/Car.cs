using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TelemetrikCar.Model
{
    public class Car
    {
        [Key]
        public int IdCar { get; set; }
        public String Name { get; set; }
        public String Typ { get; set; }
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }
        [DataType(DataType.Date)]
        public DateTime ModifiedAt { get; set; }
        public ICollection<Telemetrik> Telemetriks { get; set; }
    }
}
