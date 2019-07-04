using System;
using System.Collections.Generic;

namespace BlazorProject.Server.Models
{
    public partial class Generation
    {
        public int Id { get; set; }
        public int MainRegionId { get; set; }
        public string Name { get; set; }

        public virtual MainRegion MainRegion { get; set; }
    }
}
