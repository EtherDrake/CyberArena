using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CyberArena.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CyberArena.DAL
{
    public class ArenaContext:DbContext
    {
        public ArenaContext() : base("ArenaContext")
        {
        }

        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}