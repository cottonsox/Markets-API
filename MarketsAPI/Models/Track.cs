using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketsAPI.Enum;

namespace MarketsAPI.Models
{


    public class Track
    {
        public Guid id { get; set; }
        public String Name { get; set; }
        public String Code { get; set; }
        public State State { get; set; }
        public TrackSurface Surface { get; set; }

    }
}
