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
            PokemonAbilities = new HashSet<PokemonAbilities>();
            PokemonMoves = new HashSet<PokemonMoves>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int SpeciesId { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public int BaseExperience { get; set; }
        public int Position { get; set; }
        public bool IsDefault { get; set; }

        public Species Species { get; set; }
        public PokemonStats PokemonStats { get; set; }
        public ICollection<PokemonTypes> PokemonTypes { get; set; }
        public ICollection<PokemonAbilities> PokemonAbilities { get; set; }
        public ICollection<PokemonMoves> PokemonMoves { get; set; }
    }
}
