using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public enum Rank
    {
        Admin,
        User
    }
    public class WS_Rank:BaseEntity
    {
        public Rank Rank { get; set; } = Rank.User;
    }
}
