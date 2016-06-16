using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketsAPI.Enum;
using System.ComponentModel.DataAnnotations;

namespace MarketsAPI.Models
{
    
   public class Horse
    {
        [Required]
        public Guid Id{ get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set;}
        public int Age { get; set; }
        public HorseGender Gender { get; set; }

    }
}
