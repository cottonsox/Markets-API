using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarketsAPI.Models
{
    public class RaceResult
    {
        public Guid Id { get; set; }
        public Guid RaceHorseId { get; set; }
        public int Position { get; set; }
        public float Margin { get; set; } //This might need to change it is abit ambigous (could be margin from winner?) || Lengths


        public virtual RaceHorse RaceHorse { get; set; }


    }
}