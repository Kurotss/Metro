using System;
using System.Collections.Generic;

#nullable disable

namespace Metro
{
    public partial class Station
    {
        public Station()
        {
            StopTrafficIdFirstStationNavigations = new HashSet<StopTraffic>();
            StopTrafficIdSecondStationNavigations = new HashSet<StopTraffic>();
        }

        public int IdStation { get; set; }
        public int? IdLine { get; set; }
        public string GpsCoordinates { get; set; }
        public double? PassengerTraffic { get; set; }
        public string NameStation { get; set; }

        public virtual Line IdLineNavigation { get; set; }
        public virtual ICollection<StopTraffic> StopTrafficIdFirstStationNavigations { get; set; }
        public virtual ICollection<StopTraffic> StopTrafficIdSecondStationNavigations { get; set; }
    }
}
