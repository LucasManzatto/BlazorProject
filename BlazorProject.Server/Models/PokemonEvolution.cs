namespace BlazorProject.Server.Models
{
    public class PokemonEvolution
    {
        public int Id { get; set; }
        public int EvolvedSpeciesId { get; set; }
        public int EvolutionTriggerId { get; set; }
        public int? TriggerItemId { get; set; }
        public int? MinimumLevel { get; set; }
        public int? Gender { get; set; }
        public int? LocationId { get; set; }
        public int? HeldItemId { get; set; }
        public string TimeOfDay { get; set; }
        public int? KnownMoveId { get; set; }
        public int? KnownMoveTypeId { get; set; }
        public int? MinimumHappiness { get; set; }
        public int? MinimumBeauty { get; set; }
        public int? MinimumAffection { get; set; }
        public int? RelativePhysicalStats { get; set; }
        public int? PartySpeciesId { get; set; }
        public int? PartyTypeId { get; set; }
        public int? TradeSpeciesId { get; set; }
        public bool NeedsOverworldRain { get; set; }
        public bool TurnUpsideDown { get; set; }

        public virtual EvolutionTriggers EvolutionTrigger { get; set; }
        public virtual Species EvolvedSpecies { get; set; }
        public virtual Items HeldItem { get; set; }
        public virtual Moves KnownMove { get; set; }
        public virtual Types KnownMoveType { get; set; }
        public virtual Locations Location { get; set; }
        public virtual Species PartySpecies { get; set; }
        public virtual Types PartyType { get; set; }
        public virtual Species TradeSpecies { get; set; }
        public virtual Items TriggerItem { get; set; }
    }
}