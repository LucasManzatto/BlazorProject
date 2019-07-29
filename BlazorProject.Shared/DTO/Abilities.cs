using System;
using System.Collections.Generic;

namespace BlazorProject.Shared.DTO
{
    public partial class Abilities
    {
        public string Name { get; set; }
        public string ShortEffect { get; set; }
        public string Effect { get; set; }
        public AbilitiesProse AbilitiesProse { get; set; }
    }
}
