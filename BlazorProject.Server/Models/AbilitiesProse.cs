namespace BlazorProject.Server.Models
{
    public sealed class AbilitiesProse
    {
        public int Id { get; set; }
        public int AbilityId { get; set; }
        public string ShortEffect { get; set; }
        public string Effect { get; set; }
        public Abilities Ability { get; set; }
    }
}