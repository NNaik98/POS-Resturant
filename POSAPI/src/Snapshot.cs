using System;
using System.ComponentModel.DataAnnotations;

namespace POSAPI.EffectiveDating
{
    public abstract class Snapshot
    {
        public string Id { get; set; }

        [Required]
        public DateTime EffectiveDate { get; set; }

        public Snapshot()
        {
            
        }

        public Snapshot(string id , DateTime effectiveDate)
        {
            Id = id;
            EffectiveDate = effectiveDate;

        }
    }


}
