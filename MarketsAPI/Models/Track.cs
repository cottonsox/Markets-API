using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketsAPI.Enum;
using System.ComponentModel.DataAnnotations;

namespace MarketsAPI.Models
{


    public class Track
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public String Name { get; set; }

        public String Code { get; set; }
        public State State { get; set; }

        [Required]
        public TrackSurface Surface { get; set; }

    }
}
