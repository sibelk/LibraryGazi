using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryGazi.Entity
{
    public class Author
    {
        public int Id { get; set; }
        public string author_name { get; set; }
        public List<Book> books { get; set; }
    }
}