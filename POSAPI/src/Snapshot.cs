using System;
using System.ComponentModel.DataAnnotations;

namespace POSAPI.EffectiveDating
{
    public abstract class Snapshot
    {
        public string Id { get; set; }

        [Required]
        public DateOnly EffectiveDate { get; set; }
    }
}
