using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketsAPI.Enum;

namespace MarketsAPI.Models
{
    public class Jockey
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }
        public int LowWeight { get; set; }
        public Boolean Isapprentice { get; set; }
        public int ApprenticeClaim { get; set; }
        public Gender Gender { get; set; }
    }
}
