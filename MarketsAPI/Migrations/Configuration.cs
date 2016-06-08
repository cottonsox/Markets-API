namespace MarketsAPI.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using MarketsAPI.Models;


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
                new Track { Name = "Launceston", State = "TAS", Surface = Surface.Turf },
                new Track { Name = "Hobart", State = "TAS", Surface = Surface.Turf },
                new Track { Name = "Spreyton", State = "TAS", Surface = Surface.Tapeta },
                new Track { Name = "Morphetville", State = "SA", Surface = Surface.Turf }

                );
        }
    }
}

