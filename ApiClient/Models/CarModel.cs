using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ApiClient.Models
{
    public class Car
    {
        public int IdCar { get; set; }

        public string Name { get; set; } = string.Empty;
        public string Typ { get; set; } = string.Empty;
        public DateTime? CreatedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }

        [JsonIgnore]
        public string CreatedAtFormatted => CreatedAt == null ? "-" : ((DateTime)CreatedAt).ToString(Thread.CurrentThread.CurrentCulture);
        [JsonIgnore]
        public string ModifiedAtFormatted => ModifiedAt == null ? "-" : ((DateTime)ModifiedAt).ToString(Thread.CurrentThread.CurrentCulture);
    }
}
