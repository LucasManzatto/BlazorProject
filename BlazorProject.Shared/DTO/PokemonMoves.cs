using System;
using System.Collections.Generic;

namespace BlazorProject.Shared.DTO
{
    public partial class PokemonMoves
    {
        public int? Level { get; set; }
        public int? Order { get; set; }
        public string DamageClass { get; set; }
        public string Name { get; set; }
        public int? Power { get; set; }
        public int? Accuracy { get; set; }
        public string Type { get; set; }
        public string LearnMethods { get; set; }
        public int TmMachineNumber { get; set; }
    }
}
