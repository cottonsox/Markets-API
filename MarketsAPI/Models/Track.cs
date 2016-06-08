using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketsAPI.Models
{
    public enum Surface
    {
        Turf,
        Dirt,
        Tapeta,
        ProRide // Same as Tapeta?? 
    }

    public class Track
    {
        public Guid id { get; set; }
        public String Name { get; set; }
        public String State { get; set; }
        public Surface Surface { get; set; }

    }
}
