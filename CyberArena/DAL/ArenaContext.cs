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
            modelBuilder.HasDefaultSchema("dbo");

            modelBuilder.Entity<Player>().ToTable("Player");
            modelBuilder.Entity<Team>().ToTable("Team");

            modelBuilder.Entity<Player>().HasKey<int>(s => s.ID);
            modelBuilder.Entity<Team>().HasKey<int>(s => s.ID);


            modelBuilder.Entity<Player>().Property(p => p.FirstName).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Player>().Property(p => p.LastName).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Player>().Property(p => p.Nickname).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Player>().Property(p => p.MMR).IsRequired();
            modelBuilder.Entity<Player>().Property(p => p.TeamID).IsRequired();

            modelBuilder.Entity<Team>().Property(p => p.Name).IsRequired().HasMaxLength(20);
            modelBuilder.Entity<Team>().Property(p => p.Rating).IsRequired();

            modelBuilder.Entity<Player>()
                .HasRequired<Team>(p => p.Team)
                .WithMany(t => t.Players)
                .HasForeignKey<int>(p => p.TeamID);
        }
    }
}