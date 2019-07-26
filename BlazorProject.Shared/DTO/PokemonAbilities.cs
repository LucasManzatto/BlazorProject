using System;
using System.Collections.Generic;

namespace BlazorProject.Shared.DTO
{
    public partial class PokemonAbilities
    {
        public int Id { get; set; }
        public bool IsHidden { get; set; }
        public int Slot { get; set; }
        public Abilities Ability { get; set; }
    }
}
