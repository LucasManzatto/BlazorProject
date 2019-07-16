using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorProject.Server.Models
{
    public partial class Pokemons
    {
        public Pokemons()
        {
            PokemonTypes = new HashSet<PokemonTypes>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int SpeciesId { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public int BaseExperience { get; set; }
        public int Position { get; set; }
        public bool IsDefault { get; set; }

        public virtual Species Species { get; set; }
        public virtual PokemonStats PokemonStats { get; set; }
        public virtual ICollection<PokemonTypes> PokemonTypes { get; set; }
    }
}
