using System;
using System.Collections.Generic;

namespace BlazorProject.Shared.DTO
{
    public partial class AbilitiesProse
    {
        public int Id { get; set; }
        public int AbilityId { get; set; }
        public string ShortEffect { get; set; }
        public string Effect { get; set; }

        public Abilities Ability { get; set; }
    }
}
