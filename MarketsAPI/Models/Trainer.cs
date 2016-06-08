using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketsAPI.Models
{
    public enum Gender { Male,Female};

    public class Trainer
    {
        public Guid id { get; set; }
        public string FirstName { get; set; }
        public string Surname { get; set; }

        public Gender Gender { get; set; }
    }
}
