using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketsAPI.Models
{
    public class Race
    {
        public Guid Id { get; set; }
        public Guid RaceMeetId {get;set;}
        public int Distance { get; set; }
        public int RaceNumber { get; set;}
        public virtual RaceMeet RaceMeet { get; set; }

    }
}
