using System;
using System.Collections.Generic;

namespace BlazorProject.Server.Models
{
    public partial class Pokemons
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SpeciesId { get; set; }
        public int Height { get; set; }
        public int Weight { get; set; }
        public int BaseExperience { get; set; }
        public int Position { get; set; }
        public bool IsDefault { get; set; }

        public virtual Species Species { get; set; }
    }
}
