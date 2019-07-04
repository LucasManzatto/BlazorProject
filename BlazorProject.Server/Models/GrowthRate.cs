using System;
using System.Collections.Generic;

namespace BlazorProject.Server.Models
{
    public partial class GrowthRate
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Formula { get; set; }
    }
}
