using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketsAPI.Enum;
using System.ComponentModel.DataAnnotations;

namespace MarketsAPI.Models
{
    public class RaceMeet
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid TrackId { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public string Desription { get; set; }
        public int RaceCount { get; set; }
        public TrackConditions TrackCondition { get; set; }

        public virtual Track Track { get; set; }
    }
}
