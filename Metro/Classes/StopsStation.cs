using System;
using System.Collections.Generic;

#nullable disable

namespace Metro
{
    public partial class StopsStation
    {
        public DateTime? DateStartStop { get; set; }
        public DateTime? DateEndStop { get; set; }
        public string NameFirst { get; set; }
        public string NameSecond { get; set; }
        public int IdStop { get; set; }
    }
}
