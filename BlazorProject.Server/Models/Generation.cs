using System.Collections.Generic;

namespace BlazorProject.Server.Models
{
    public sealed class Generation
    {
        public int Id { get; set; }
        public int MainRegionId { get; set; }
        public string Name { get; set; }
        public MainRegion MainRegion { get; set; }
        public ICollection<Species> Species { get; set; } = new HashSet<Species>();
        public ICollection<Types> Types { get; set; } = new HashSet<Types>();
    }
}