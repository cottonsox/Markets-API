using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketsAPI.Enum;
using System.ComponentModel.DataAnnotations;

namespace MarketsAPI.Models
{
    public class Jockey
    {
        [Required]
        public Guid Id { get; set; }
  
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(100)]
        public string Surname { get; set; }
        public int LowWeight { get; set; }
        public Boolean Isapprentice { get; set; }
        public int ApprenticeClaim { get; set; }
        public Gender Gender { get; set; }
    }
}
