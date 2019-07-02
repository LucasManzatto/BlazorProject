using System;
using System.Collections.Generic;

namespace BlazorProject.Server.Models
{
    public partial class MainRegion
    {
        public MainRegion()
        {
            Generation = new HashSet<Generation>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Generation> Generation { get; set; }
    }
}
