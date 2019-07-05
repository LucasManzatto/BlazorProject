using System;
using System.Collections.Generic;

namespace BlazorProject.Server.Models
{
    public partial class Species
    {
        public Species()
        {
            InverseEvolvesFromSpecies = new HashSet<Species>();
            Pokemons = new HashSet<Pokemons>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int GenerationId { get; set; }
        public int? EvolvesFromSpeciesId { get; set; }
        public int EvolutionChain { get; set; }
        public int GenderRate { get; set; }
        public int CaptureRate { get; set; }
        public int BaseHappiness { get; set; }
        public bool IsBaby { get; set; }
        public int HatchCounter { get; set; }
        public bool HasGenderDifferences { get; set; }
        public int GrowthRateId { get; set; }
        public bool FormsSwitchable { get; set; }
        public int Position { get; set; }

        public virtual Species EvolvesFromSpecies { get; set; }
        public virtual Generation Generation { get; set; }
        public virtual GrowthRate GrowthRate { get; set; }
        public virtual ICollection<Species> InverseEvolvesFromSpecies { get; set; }
        public virtual ICollection<Pokemons> Pokemons { get; set; }
    }
}
