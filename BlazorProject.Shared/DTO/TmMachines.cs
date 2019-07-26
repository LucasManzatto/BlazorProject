using System;
using System.Collections.Generic;

namespace BlazorProject.Shared.DTO
{
    public partial class TmMachines
    {
        public int Id { get; set; }
        public int MachineNumber { get; set; }
        public VersionGroups VersionGroup { get; set; }
    }
}
