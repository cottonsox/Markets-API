using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketsAPI.Models
{
    class Jockey
    {
        public Guid id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int LowWeight { get; set; }
        public Boolean Isapprentice { get; set; }
        public int ApprenticeClaim { get; set; }
        public char Gender { get; set; }
    }
}
