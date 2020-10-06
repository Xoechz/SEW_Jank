using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TelemetrikCar.Model
{
    public class Telemetrik
    {
        private int IdTel { get; set; }
        private Car Car { get; set; }
        private double Latitude{ get; set; }
        private double Longitude{ get; set; }
        private double Speed{ get; set; }
        private double Capacity{ get; set; }

    }
}
