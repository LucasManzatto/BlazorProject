namespace BlazorProject.Server.Models
{
    public class VersionGroups
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenerationId { get; set; }
        public int Order { get; set; }
        public virtual Generation Generation { get; set; }
    }
}