using System;
using System.Collections.Generic;

namespace BlazorProject.Server.Models
{
    public partial class VersionGroups
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int GenerationId { get; set; }
        public int Order { get; set; }
        public virtual Generation Generation { get; set; }
    }
}
