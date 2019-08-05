using System.Collections.Generic;

namespace BlazorProject.Server.Models
{
    public sealed class MainRegion
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Generation> Generation { get; set; } = new HashSet<Generation>();
    }
}