using System;
using System.Collections.Generic;

namespace BlazorProject.Server.Models
{
    public partial class TmMachines
    {
        public int Id { get; set; }
        public int MachineNumber { get; set; }
        public int VersionGroupId { get; set; }
        public int ItemId { get; set; }
        public int MoveId { get; set; }
        public VersionGroups VersionGroup { get; set; }
        public Items Item { get; set; }
        public Moves Move { get; set; }
    }
}
