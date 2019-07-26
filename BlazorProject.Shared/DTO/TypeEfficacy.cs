namespace BlazorProject.Shared.DTO
{
    public partial class TypeEfficacy
    {
        public int Id { get; set; }
        public int DamageFactor { get; set; }
        public Types DamageType { get; set; }
        public Types TargetType { get; set; }
    }
}
