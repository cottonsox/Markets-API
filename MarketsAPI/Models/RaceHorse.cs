using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketsAPI.Models
{
    public class RaceHorse 
    {
        public Guid id { get; set; }
        public Guid RaceId {get;set;}
        public Guid JockeyId { get; set; }
        public Guid HorseId { get; set; }
        public Guid TrainerId { get; set; }
        public int Barrier { get; set; }
        public float Weight { get; set; }

        public virtual Race Race { get; set; }
        public virtual Horse Horse { get; set; }
        public virtual Jockey Jockey { get; set; }
        public virtual Trainer Trainer { get; set; }
    }
}
