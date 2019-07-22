using System;
using System.Collections.Generic;

namespace BlazorProject.Server.Models
{
    public partial class ItemCategories
    {
        public int Id { get; set; }
        public int ItemPocketId { get; set; }
        public string Name { get; set; }
        public virtual ItemPockets ItemPocket { get; set; }
    }
}
