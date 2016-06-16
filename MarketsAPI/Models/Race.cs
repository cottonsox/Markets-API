using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketsAPI.Models
{
    public class Race
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid RaceMeetId {get;set;}
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public int Distance { get; set; }
        public int RaceNumber { get; set;}



        public virtual RaceMeet RaceMeet { get; set; }

    }
}
