using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class WS_OrdreLinje:BaseEntity
    {
        public WS_Vare Vare { get; set; }
        public WS_Ordre Ordre { get; set; }
        public int Antal { get; set; }
        public double EnhedsPris { get; set; }
    }
}
