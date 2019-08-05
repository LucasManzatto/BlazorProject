namespace BlazorProject.Server.Models
{
    public class TypeEfficacy
    {
        public int Id { get; set; }
        public int DamageTypeId { get; set; }
        public int TargetTypeId { get; set; }
        public int DamageFactor { get; set; }

        public Types DamageType { get; set; }
        public Types TargetType { get; set; }
    }
}