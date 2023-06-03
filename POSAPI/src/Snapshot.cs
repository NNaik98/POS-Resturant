using System;
using System.ComponentModel.DataAnnotations;

namespace POSAPI.EffectiveDating
{
    public abstract class Snapshot
    {
        public string Id { get; protected set; }

        [Required]
        public DateOnly EffectiveDate { get; protected set; }
    }
}
