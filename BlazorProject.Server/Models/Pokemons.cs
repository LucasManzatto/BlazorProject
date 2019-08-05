using System.Collections.Generic;

namespace BlazorProject.Server.Models
{
    public class Pokemons
    {
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
        public ICollection<PokemonTypes> PokemonTypes { get; set; } = new HashSet<PokemonTypes>();
        public ICollection<PokemonAbilities> PokemonAbilities { get; set; } = new HashSet<PokemonAbilities>();
        public ICollection<PokemonMoves> PokemonMoves { get; set; } = new HashSet<PokemonMoves>();
    }
}