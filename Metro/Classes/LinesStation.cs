using System;
using System.Collections.Generic;

#nullable disable

namespace Metro
{
    public partial class LinesStation
    {
        public string NameLine { get; set; }
        public string NameStation { get; set; }
        public string GpsCoordinates { get; set; }
        public double? PassengerTraffic { get; set; }
    }
}
