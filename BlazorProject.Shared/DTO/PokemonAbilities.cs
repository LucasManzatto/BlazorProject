using System;
using System.Collections.Generic;

namespace BlazorProject.Shared.DTO
{
    public partial class PokemonAbilities
    {
        public string Effect { get; set; }
        public bool IsHidden { get; set; }
        public string Name { get; set; }
        public string ShortEffect { get; set; }
        public int Slot { get; set; }
    }
}
