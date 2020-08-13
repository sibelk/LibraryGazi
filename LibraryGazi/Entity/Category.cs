using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryGazi.Entity
{
    public class Category
    {
        public int Id { get; set; }
        public string category_name { get; set; }
        public List<Book> books { get; set; }

    }
}