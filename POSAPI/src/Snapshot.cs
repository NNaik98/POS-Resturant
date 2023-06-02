using System;

namespace POSAPI.EffectiveDating
{
    public abstract class Snapshot
    {
        public DateOnly EffectiveDate { get; set; }
    }
}
