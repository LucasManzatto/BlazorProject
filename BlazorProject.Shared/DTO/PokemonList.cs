using System;
using System.Collections.Generic;

namespace BlazorProject.Shared.DTO
{
    public partial class PokemonList
    {
        public PokemonList()
        {
            Types = new List<string>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<string> Types { get; set; }

        public string Generation { get; set; }
    }
}
