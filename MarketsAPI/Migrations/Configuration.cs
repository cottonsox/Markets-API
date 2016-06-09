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
                new Horse { Name = "Admiral",Age = 4, Gender =  HorseGender.Gelding },
                new Horse { Name = "Black Heart Bar", Age = 5, Gender = HorseGender.Gelding },
                new Horse { Name = "Under The Lourve", Age = 5, Gender = HorseGender.Stallion },
                new Horse { Name = "Malaguerra", Age = 4, Gender = HorseGender.Gelding }
                );

            context.Trainers.AddOrUpdate(
                T => T.FirstName,
                new Trainer { FirstName = "Barry", Surname = "Campbell", Gender = Gender.Male},
                new Trainer { FirstName = "Darren", Surname = "Weir" , Gender = Gender.Male },
                new Trainer { FirstName = "Chris", Surname = "Waller" , Gender = Gender.Male }                
                );


            context.Tracks.AddOrUpdate(
                T => T.Name,
                new Track { Name = "Launceston", State = State.TAS, Surface = TrackSurface.Turf, Code="MOWB"},
                new Track { Name = "Hobart", State = State.TAS, Surface = TrackSurface.Turf ,Code = "ELWK" },
                new Track { Name = "Spreyton", State = State.TAS, Surface = TrackSurface.Tapeta,Code = "SPRY" },
                new Track { Name = "Morphetville", State = State.SA, Surface = TrackSurface.Turf , Code = "MORP" }
                );

            context.Jockeys.AddOrUpdate(
                J => J.FirstName,
                new Jockey { FirstName = "Brendan", Surname = "McCoull", Gender = Gender.Male },
                new Jockey { FirstName = "David", Surname = "Pires", Gender = Gender.Male },
                new Jockey { FirstName = "Siggy", Surname = "Carr", Gender = Gender.Female },
                new Jockey { FirstName = "Damien", Surname = "Oliver", Gender = Gender.Male }

                );
        }
    }
}

