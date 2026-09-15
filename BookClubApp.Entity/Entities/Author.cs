using BookClubApp.Entity.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookClubApp.Entity.Entities
{
    public class Author:BaseEntity
    {
        public string FullName { get; set; } = string.Empty;
        public string? Biography { get; set; }
        //nav menu
        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
