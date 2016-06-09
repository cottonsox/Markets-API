using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketsAPI.Enum;

namespace MarketsAPI.Models
{
    public class RaceMeet
    {
        public Guid Id { get; set; }
        public Guid TrackId { get; set; }
        public DateTime Date { get; set; }
        public int RaceCount { get; set; }
        public TrackConditions TrackCondition { get; set; }

        public virtual Track Track { get; set; }
    }
}
