using System;
using System.Collections.Generic;

namespace BlazorProject.Shared.DTO
{
    public partial class Manga : BaseEntity
    {
        public string Title { get; set; }
        public int? Volumes { get; set; }

        //public virtual Author Author { get; set; }
    }
}
