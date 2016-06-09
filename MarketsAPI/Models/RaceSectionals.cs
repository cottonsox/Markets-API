using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketsAPI.Models
{
    public class RaceSectionals
    {
        public Guid Id { get; set; }
        public Guid RaceResultId { get; set; }
        
        public float SectionTime { get; set; }
        public int SectionStart { get; set; }
        public int Sectionend { get; set; }




        public virtual RaceResult RaceResult { get; set; }

    }
}