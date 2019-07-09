using System;
using System.Collections.Generic;

namespace BlazorProject.Server.Models
{
    public partial class DamageClass
    {
        public DamageClass()
        {
            Types = new HashSet<Types>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Types> Types { get; set; }
    }
}
