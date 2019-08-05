namespace BlazorProject.Server.Models
{
    public class PokemonTypes
    {
        public int Id { get; set; }
        public int PokemonId { get; set; }
        public int TypeId { get; set; }
        public int Slot { get; set; }

        public virtual Pokemons Pokemon { get; set; }
        public virtual Types Type { get; set; }
    }
}