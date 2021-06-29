using System;
using System.Collections.Generic;

#nullable disable

namespace Metro
{
    public partial class Line
    {
        public Line()
        {
            Stations = new HashSet<Station>();
        }

        public int IdLine { get; set; }
        public string NameLine { get; set; }
        public double? LengthLine { get; set; }
        public int? FirstDateOpenStation { get; set; }

        public virtual ICollection<Station> Stations { get; set; }
    }
}
