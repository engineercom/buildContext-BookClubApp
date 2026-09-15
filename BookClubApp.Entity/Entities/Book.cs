using BookClubApp.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClubApp.Entity.Entities
{
    public class Book:BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTime PublishedDate { get; set; }

        public int AuthorId { get; set; }
        //navigation menu
        public Author Author { get; set; }

        public ICollection<Category> Categories { get; set; } = new HashSet<Category>();
    }
}
