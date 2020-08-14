using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Model
{
    public class WS_UserRank:BaseEntity
    {
        public WS_Rank Rank { get; set; } = new WS_Rank();
        public WS_User User { get; set; }
    }
}
