using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using System.Web;
using MarketsAPI.Models;
using MarketsAPI.Controllers;
using MarketsAPI.Enum;

using System.Collections.Generic;

namespace MarketsAPI.Tests
{
    [TestClass]
    public class TestHorseController
    {
        [TestMethod]
        public void GetAllHorses()
        {
            var testHorse = GetTestHorses();
            var Controller = new HorseController();

            var result = Controller.GetHorses() as List<Horse>;
            Assert.AreEqual(testHorse.Count, result.Count);
            
        }

        private List<Horse> GetTestHorses()
        {
            var TestHorses = new List<Horse>();

            TestHorses.Add(new Horse { Name = "Admiral", Age = 4, Gender = HorseGender.Gelding });
            TestHorses.Add(new Horse { Name = "Black Heart Bar", Age = 5, Gender = HorseGender.Gelding });
            TestHorses.Add(new Horse { Name = "Under The Lourve", Age = 5, Gender = HorseGender.Stallion });
            TestHorses.Add(new Horse { Name = "Malaguerra", Age = 4, Gender = HorseGender.Gelding });

            return TestHorses;
        }
    }
}
