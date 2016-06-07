using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketsAPI.Models
{
   public class Horse
    {
        public Guid id{ get; set; }
        public string Name { get; set;}
        public int Age { get; set; }
        public char Gender { get; set; }

    }
}
