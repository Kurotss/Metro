using System;
using System.Collections.Generic;

#nullable disable

namespace Metro
{
    public partial class StopTraffic
    {
        public int IdStop { get; set; }
        public DateTime? DateStartStop { get; set; }
        public DateTime? DateEndStop { get; set; }
        public int? IdFirstStation { get; set; }
        public int? IdSecondStation { get; set; }

        public virtual Station IdFirstStationNavigation { get; set; }
        public virtual Station IdSecondStationNavigation { get; set; }
    }
}
