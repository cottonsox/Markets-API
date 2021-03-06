﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketsAPI.Models;
using MarketsAPI.Controllers;
using MarketsAPI.Enum;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MarketsAPI.Tests
{
    [TestClass]
    public class TestHorseController
    {
        public object JsonConvert { get; private set; }

        [TestMethod]
        public void GetAllHorses()
        {
            var testHorse = GetTestHorses();
            var Controller = new HorseController();
             
          //  var result = Controller.GetHorses() as string;
         //  Assert.AreEqual(testHorse.Count, result.Count);
            
        }

        private String GetTestHorses()
        {
            var TestHorses = new List<Horse>();

            TestHorses.Add(new Horse { Name = "Admiral", Age = 4, Gender = HorseGender.Gelding });
            TestHorses.Add(new Horse { Name = "Black Heart Bart", Age = 5, Gender = HorseGender.Gelding });
            TestHorses.Add(new Horse { Name = "Under The Lourve", Age = 5, Gender = HorseGender.Stallion });
            TestHorses.Add(new Horse { Name = "Malaguerra", Age = 4, Gender = HorseGender.Gelding });

            return string.Empty;
            //return JsonConvert.SerializeObject(TestHorses);

        }
    }
}
