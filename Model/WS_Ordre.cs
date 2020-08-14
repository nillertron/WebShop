using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class WS_Ordre : BaseEntity
    {
        public DateTime Bestilt { get; set; }

        public WS_User User { get; set; }
        public List<WS_OrdreLinje> OrdreLinjer { get; set; } = new List<WS_OrdreLinje>();
        public bool Paid { get; set; } = false;
    }
}
