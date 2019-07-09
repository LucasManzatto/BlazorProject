using System;
using System.Collections.Generic;

namespace BlazorProject.Shared.DTO
{
    public partial class Types
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public int GenerationId { get; set; }
        public int? DamageClassId { get; set; }

        public DamageClass DamageClass { get; set; }
        //public Generation Generation { get; set; }
    }
}
