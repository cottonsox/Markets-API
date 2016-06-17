using MarketsAPI.Models;
using MarketsAPI.Infrastructure;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;


namespace MarketsAPI.Data
{
    class MarketsContext : IdentityContext
    {

        public MarketsContext() : base() { }

     
        public DbSet<Horse> Horses { get; set; }
        public DbSet<Jockey> Jockeys { get; set; }
        public DbSet<Trainer> Trainers { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<RaceMeet> RaceMeets { get; set; }
        public DbSet<RaceHorse> RaceHorses { get; set; }
        public DbSet<Track> Tracks { get; set; }

        public DbSet<RaceResult> RaceResult { get; set; }
        public DbSet<RaceSectionals> RaceSectionals { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

