
namespace BlazorProject.Server.Models
{
    public partial class TypeEfficacy
    {
        public int Id { get; set; }
        public int DamageTypeId { get; set; }
        public int TargetTypeId { get; set; }
        public int DamageFactor { get; set; }

        public virtual PokemonTypes DamageType { get; set; }
        public virtual PokemonTypes TargetType { get; set; }
    }
}
