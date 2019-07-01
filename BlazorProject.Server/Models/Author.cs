using System;
using System.Collections.Generic;

namespace BlazorProject.Server.Models
{
    public partial class Author : BaseEntity
    {
        public Author()
        {
            Manga = new HashSet<Manga>();
        }
        public string Name { get; set; }

        public virtual ICollection<Manga> Manga { get; set; }
    }
}
