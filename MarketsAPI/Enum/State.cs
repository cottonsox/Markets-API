using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketsAPI.Enum
{
    public enum State
    {
        [Display(Name = "Tasmania")]
        TAS,
        [Display(Name = "Victoria")]
        VIC,
        [Display(Name = "South Australia")]
        SA,
        [Display(Name = "New South Wales")]
        NSW,
        [Display(Name = "Australian Capital Territory")]
        ACT,
        [Display(Name = "Queensland")]
        QLD,
        [Display(Name = "Western Australia")]
        WA,
        [Display(Name = "Northern Territory")]
        NT
    }
}