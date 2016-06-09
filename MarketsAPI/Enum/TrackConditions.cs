using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MarketsAPI.Enum
{
    public enum TrackConditions
    {
        [Display(GroupName ="Turf", Name = "Firm 1")]
        Firm1,
        [Display(GroupName = "Turf", Name = "Firm 2")]
        Firm2,
        [Display(GroupName = "Turf", Name = "Good 3")]
        Good3,
        [Display(GroupName = "Turf", Name = "Good 4")]
        Good4,
        [Display(GroupName = "Turf", Name = "Slow 5")]
        Slow5,
        [Display(GroupName = "Turf", Name = "Slow 6")]
        Slow6,
        [Display(GroupName = "Turf", Name = "Slow 7")]
        Slow7,
        [Display(GroupName = "Turf", Name = "Heavy 8")]
        Heavy8,
        [Display(GroupName = "Turf", Name = "Heavy 9")]
        Heavy9,
        [Display(GroupName = "Turf", Name = "Heavy 10")]
        Heavy10,
        [Display(GroupName = "Dirt/Sand", Name = "Fast")]
        Fast,
        [Display(GroupName = "Dirt/Sand", Name = "Good")]
        Good,
        [Display(GroupName = "Dirt/Sand", Name = "Soft")]
        Soft,
        [Display(GroupName = "Dirt/Sand", Name = "Fast Wet")]
        WetFast
    }
}