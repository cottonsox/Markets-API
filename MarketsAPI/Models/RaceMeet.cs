using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketsAPI.Models
{
    class RaceMeet
    {
        public Guid id { get; set; }
        public Guid TrackId { get; set; }
        public DateTime Date { get; set; }
        public int RaceCount { get; set; }
        
        public virtual Track Track { get; set; }
    }
}
