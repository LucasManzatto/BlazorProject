using System;
using System.Collections.Generic;

namespace BlazorProject.Server.Models
{
    public partial class PokemonStats
    {
        public int Id { get; set; }
        public int PokemonId { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int SpAttack { get; set; }
        public int SpDefense { get; set; }
        public int Speed { get; set; }

        public virtual Pokemons Pokemon { get; set; }
    }
}
