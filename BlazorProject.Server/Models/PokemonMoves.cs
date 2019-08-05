namespace BlazorProject.Server.Models
{
    public class PokemonMoves
    {
        public int Id { get; set; }
        public int PokemonId { get; set; }
        public int? VersionGroupId { get; set; }
        public int? MoveId { get; set; }
        public int? MoveLearnMethodsId { get; set; }
        public int? Level { get; set; }
        public int? Order { get; set; }
        public virtual Moves Move { get; set; }
        public virtual MoveLearnMethods MoveLearnMethods { get; set; }
        public virtual Pokemons Pokemon { get; set; }
        public virtual VersionGroups VersionGroup { get; set; }
    }
}