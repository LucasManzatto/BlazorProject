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

        public DamageClass DamageClass { get; set; }
        public Generation Generation { get; set; }
        public MoveEffects MoveEffect { get; set; }
        public MoveTargets MoveTarget { get; set; }
        public Types Type { get; set; }
    }
}
