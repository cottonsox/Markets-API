using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketsAPI.Models
{
    public class RaceSectionals
    {
        public Guid Id { get; set; }
        public Guid HorseId { get; set; }
        public Guid RaceHorseId { get; set; }
        public Guid RaceId { get; set; }


        public virtual Race Race { get; set; }
        public virtual RaceHorse RaceHorse { get; set; }
        public virtual Horse Horse { get; set; }

    }
}