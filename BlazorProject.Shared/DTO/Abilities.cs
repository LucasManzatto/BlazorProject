using System;
using System.Collections.Generic;

namespace BlazorProject.Shared.DTO
{
    public partial class Abilities
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenerationId { get; set; }
        public string ShortEffect { get; set; }
        public string Effect { get; set; }
        public bool IsMainSeries { get; set; }

        public virtual Generation Generation { get; set; }
        public virtual AbilitiesProse AbilitiesProse { get; set; }
    }
}
