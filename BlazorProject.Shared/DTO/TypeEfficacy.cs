
namespace BlazorProject.Shared.DTO
{
    public partial class TypeEfficacy
    {
        public int Id { get; set; }
        public int DamageFactor { get; set; }
        public virtual Types DamageType { get; set; }
        public virtual Types TargetType { get; set; }
    }
}
