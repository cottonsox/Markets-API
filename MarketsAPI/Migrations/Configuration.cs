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
                new Horse { Id = Guid.NewGuid(), Name = "Admiral",Age = 4, Gender =  HorseGender.Gelding },
                new Horse { Id = Guid.NewGuid(), Name = "Black Heart Bart", Age = 5, Gender = HorseGender.Gelding },
                new Horse { Id = Guid.NewGuid(), Name = "Under The Lourve", Age = 5, Gender = HorseGender.Stallion },
                new Horse { Id = Guid.NewGuid(), Name = "Malaguerra", Age = 4, Gender = HorseGender.Gelding }
                );

            context.Trainers.AddOrUpdate(
                T => T.FirstName,
                new Trainer { Id = Guid.NewGuid(), FirstName = "Barry", Surname = "Campbell", Gender = Gender.Male},
                new Trainer { Id = Guid.NewGuid(), FirstName = "Darren", Surname = "Weir" , Gender = Gender.Male },
                new Trainer { Id = Guid.NewGuid(), FirstName = "Chris", Surname = "Waller" , Gender = Gender.Male }                
                );


            context.Tracks.AddOrUpdate(
                T => T.Name,
                new Track { Id = Guid.NewGuid(), Name = "Launceston", State = State.TAS, Surface = TrackSurface.Turf, Code="MOWB"},
                new Track { Id = Guid.NewGuid(), Name = "Hobart", State = State.TAS, Surface = TrackSurface.Turf ,Code = "ELWK" },
                new Track { Id = Guid.NewGuid(), Name = "Spreyton", State = State.TAS, Surface = TrackSurface.Tapeta,Code = "SPRY" },
                new Track { Id = Guid.NewGuid(), Name = "Morphetville", State = State.SA, Surface = TrackSurface.Turf , Code = "MORP" }
                );

            context.Jockeys.AddOrUpdate(
                J => J.FirstName,
                new Jockey { Id = Guid.NewGuid(), FirstName = "Brendan", Surname = "McCoull", Gender = Gender.Male },
                new Jockey { Id = Guid.NewGuid(), FirstName = "David", Surname = "Pires", Gender = Gender.Male },
                new Jockey { Id = Guid.NewGuid(), FirstName = "Siggy", Surname = "Carr", Gender = Gender.Female },
                new Jockey { Id = Guid.NewGuid(), FirstName = "Damien", Surname = "Oliver", Gender = Gender.Male }

                );
        }
    }
}

