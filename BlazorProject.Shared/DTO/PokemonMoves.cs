using System;
using System.Collections.Generic;

namespace BlazorProject.Shared.DTO
{
    public partial class PokemonMoves
    {
        public int Id { get; set; }
        public int? Level { get; set; }
        public int? Order { get; set; }
        public Moves Move { get; set; }
        public virtual MoveLearnMethods MoveLearnMethods { get; set; }
        public virtual VersionGroups VersionGroup { get; set; }
    }
}
