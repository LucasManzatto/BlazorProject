using System;
using System.Collections.Generic;

namespace BlazorProject.Shared.DTO
{
    public partial class Species
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? EvolvesFromSpeciesId { get; set; }
        public int EvolutionChain { get; set; }
        public int GenderRate { get; set; }
        public int CaptureRate { get; set; }
        public int BaseHappiness { get; set; }
        public bool IsBaby { get; set; }
        public int HatchCounter { get; set; }
        public bool HasGenderDifferences { get; set; }
        public bool FormsSwitchable { get; set; }
        public int Position { get; set; }
    }
}
