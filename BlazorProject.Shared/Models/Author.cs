using System;
using System.Collections.Generic;

namespace BlazorProject.Shared.Models
{
    public partial class Author
    {
        public Author()
        {
            Manga = new HashSet<Manga>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Manga> Manga { get; set; }
    }
}
