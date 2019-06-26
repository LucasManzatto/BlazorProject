using System;
using System.Collections.Generic;

namespace BlazorProject.Shared.Models
{
    public partial class Manga
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? AuthorId { get; set; }
        public int? Volumes { get; set; }

        public virtual Author Author { get; set; }
    }
}
