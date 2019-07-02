using System;
using System.Collections.Generic;

namespace BlazorProject.Shared.DTO
{
    public partial class GrowthRate
    {
        public GrowthRate()
        {
            Species = new HashSet<Species>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Formula { get; set; }

        public virtual ICollection<Species> Species { get; set; }
    }
}
