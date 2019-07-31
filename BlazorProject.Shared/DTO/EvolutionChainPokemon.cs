namespace BlazorProject.Shared.DTO
{
    public partial class EvolutionChainPokemon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SpeciesGenerationName { get; set; }
        public string EvolutionCondition { get; set; }
        public bool SpeciesIsBaby { get; set; }
    }
}
