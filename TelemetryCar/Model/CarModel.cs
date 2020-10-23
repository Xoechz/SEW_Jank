using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TelemetryCar.Model
{
    public class CarModel
    {
        [Key] [Required] public int IdCar { get; set; }
        [Required] public String Name { get; set; }
        [Required] public String Typ { get; set; }
        [DataType(DataType.Date)] public DateTime CreatedAt { get; set; }
        [DataType(DataType.Date)] public DateTime ModifiedAt { get; set; }
        public ICollection<TelemetryModel> TelemetryCollection { get; set; }
    }
}