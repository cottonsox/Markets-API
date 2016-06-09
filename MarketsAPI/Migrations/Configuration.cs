namespace MarketsAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MarketsAPI.Models;
    using MarketsAPI.Enum;


    internal sealed class Configuration : DbMigrationsConfiguration<MarketsAPI.DAL.MarketsContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MarketsAPI.DAL.MarketsContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            context.Horses.AddOrUpdate(

                h => h.Name,
                new Horse { Id = new Guid(), Name = "Admiral",Age = 4, Gender =  HorseGender.Gelding },
                new Horse { Id = new Guid(), Name = "Black Heart Bar", Age = 5, Gender = HorseGender.Gelding },
                new Horse { Id = new Guid(), Name = "Under The Lourve", Age = 5, Gender = HorseGender.Stallion },
                new Horse { Id = new Guid(), Name = "Malaguerra", Age = 4, Gender = HorseGender.Gelding }
                );

            context.Trainers.AddOrUpdate(
                T => T.FirstName,
                new Trainer { Id = new Guid(), FirstName = "Barry", Surname = "Campbell", Gender = Gender.Male},
                new Trainer { Id = new Guid(), FirstName = "Darren", Surname = "Weir" , Gender = Gender.Male },
                new Trainer { Id = new Guid(), FirstName = "Chris", Surname = "Waller" , Gender = Gender.Male }                
                );


            context.Tracks.AddOrUpdate(
                T => T.Name,
                new Track { Id = new Guid(), Name = "Launceston", State = State.TAS, Surface = TrackSurface.Turf, Code="MOWB"},
                new Track { Id = new Guid(), Name = "Hobart", State = State.TAS, Surface = TrackSurface.Turf ,Code = "ELWK" },
                new Track { Id = new Guid(), Name = "Spreyton", State = State.TAS, Surface = TrackSurface.Tapeta,Code = "SPRY" },
                new Track { Id = new Guid(), Name = "Morphetville", State = State.SA, Surface = TrackSurface.Turf , Code = "MORP" }
                );

            context.Jockeys.AddOrUpdate(
                J => J.FirstName,
                new Jockey { Id = new Guid(), FirstName = "Brendan", Surname = "McCoull", Gender = Gender.Male },
                new Jockey { Id = new Guid(), FirstName = "David", Surname = "Pires", Gender = Gender.Male },
                new Jockey { Id = new Guid(), FirstName = "Siggy", Surname = "Carr", Gender = Gender.Female },
                new Jockey { Id = new Guid(), FirstName = "Damien", Surname = "Oliver", Gender = Gender.Male }

                );
        }
    }
}

