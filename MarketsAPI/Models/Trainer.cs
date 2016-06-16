using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketsAPI.Enum;
using System.ComponentModel.DataAnnotations;

namespace MarketsAPI.Models
{

    public class Trainer
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }
        public string Surname { get; set; }

        public Gender Gender { get; set; }
    }
}
