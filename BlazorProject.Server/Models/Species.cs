using System.Collections.Generic;

namespace BlazorProject.Server.Models
{
    public sealed class Species
    {

        // TODO: Precisa colocar de novo o campo IsBaby para a evolution chain ficar certa nos casos 
        // de evoluções que vieram em outras gerações, como o pichu
        public int Id { get; set; }
        public int GenerationId { get; set; }
        public int? EvolvesFromSpeciesId { get; set; }
        public int EvolutionChain { get; set; }
        public int GenderRate { get; set; }
        public int CaptureRate { get; set; }
        public int BaseHappiness { get; set; }
        public int HatchCounter { get; set; }
        public bool HasGenderDifferences { get; set; }
        public int GrowthRateId { get; set; }
        public bool FormsSwitchable { get; set; }
        public int Position { get; set; }
        public bool IsBaby { get; set; }
        public Species EvolvesFromSpecies { get; set; }
        public Generation Generation { get; set; }
        public GrowthRate GrowthRate { get; set; }
        public ICollection<Species> InverseEvolvesFromSpecies { get; set; } = new HashSet<Species>();
        public Pokemons Pokemon { get; set; }
    }
}