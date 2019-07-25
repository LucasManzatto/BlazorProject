using System;
using System.Collections.Generic;

namespace BlazorProject.Shared.DTO
{
    public partial class Moves
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? Power { get; set; }
        public int? Pp { get; set; }
        public int? Accuracy { get; set; }
        public int Priority { get; set; }
        public int? MoveEffectChance { get; set; }

        public virtual DamageClass DamageClass { get; set; }
        public virtual Generation Generation { get; set; }
        public virtual MoveEffects MoveEffect { get; set; }
        public virtual MoveTargets MoveTarget { get; set; }
        public virtual Types Type { get; set; }
    }
}
