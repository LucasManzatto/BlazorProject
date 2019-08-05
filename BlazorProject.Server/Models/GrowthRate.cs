using System.Collections.Generic;

namespace BlazorProject.Server.Models
{
    public sealed class GrowthRate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Formula { get; set; }
        public ICollection<Species> Species { get; set; } = new HashSet<Species>();
    }
}