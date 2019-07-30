using System;
using System.Collections.Generic;

namespace BlazorProject.Shared.DTO
{
    public partial class DropdownPokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SpeciesGenerationName { get; set; }
    }

    public partial class EvolutionChainPokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SpeciesGenerationName { get; set; }
        public string EvolutionCondition { get; set; }
        public bool SpeciesIsBaby { get; set; }
    }
    public partial class FullPokemon
    {
        public FullPokemon()
        {
            Types = new List<string>();
            Abilities = new List<PokemonAbilities>();
            Moves = new List<PokemonMoves>();
            Efficacies = new Dictionary<string,float>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public int BaseExperience { get; set; }
        public int Position { get; set; }
        public bool IsDefault { get; set; }
        public int CaptureRate { get; set; }
        public int BaseHappiness { get; set; }
        public int GenderRate { get; set; }
        public int HatchCounter { get; set; }
        public ICollection<string> Types { set; get; }
        public ICollection<PokemonAbilities> Abilities { set; get; }
        public ICollection<PokemonMoves> Moves { set; get; }
        public PokemonStats Stats { get; set; }
        public IDictionary<string,float> Efficacies { get; set; }
    }
}
