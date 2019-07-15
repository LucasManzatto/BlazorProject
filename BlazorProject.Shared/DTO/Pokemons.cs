﻿using System;
using System.Collections.Generic;

namespace BlazorProject.Shared.DTO
{
    public partial class DropdownPokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SpeciesGenerationName { get; set; }
    }

    public partial class FullPokemon
    {
        public FullPokemon()
        {
            PokemonTypes = new List<PokemonTypes>();
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
        public ICollection<PokemonTypes> PokemonTypes { set; get; }
    }
}
