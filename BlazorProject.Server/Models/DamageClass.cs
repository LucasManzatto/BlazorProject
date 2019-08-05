using System.Collections.Generic;

namespace BlazorProject.Server.Models
{
    public sealed class DamageClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Types> Types { get; set; } = new HashSet<Types>();
    }
}