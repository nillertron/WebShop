using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Model;

namespace DataAcces
{
    public class Context:DbContext
    {
        public DbSet<WS_Distributør> WS_Distributør { get; set; }
        public DbSet<WS_Ordre> WS_Ordre { get; set; }
        public DbSet<WS_Post> WS_Post { get; set; }
        public DbSet<WS_Rank> WS_Rank { get; set; }
        public DbSet<WS_User> WS_User { get; set; }
        public DbSet<WS_Vare> WS_Vare { get; set; }
        public DbSet<WS_OrdreLinje> WS_OrdreLinje { get; set; }
        public DbSet<WS_UserRank> WS_UserRank { get; set; }





        public Context(DbContextOptions<Context> context):base(context)
        {

        }
    }
}
