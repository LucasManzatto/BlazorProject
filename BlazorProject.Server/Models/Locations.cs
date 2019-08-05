namespace BlazorProject.Server.Models
{
    public class Locations
    {
        public int Id { get; set; }
        public int? MainRegionId { get; set; }
        public string Name { get; set; }

        public virtual MainRegion MainRegion { get; set; }
    }
}