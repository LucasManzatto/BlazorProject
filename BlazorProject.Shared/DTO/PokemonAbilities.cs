using System;
using System.Collections.Generic;

namespace BlazorProject.Shared.DTO
{
    public partial class PokemonAbilities
    {
        public int Id { get; set; }
        public int PokemonId { get; set; }
        public int AbilityId { get; set; }
        public bool IsHidden { get; set; }
        public int Slot { get; set; }
        public virtual Abilities Ability { get; set; }
    }
}
