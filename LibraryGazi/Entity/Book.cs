using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryGazi.Entity
{
    public class Book
    {

        public int Id { get; set; }
        public string bookName { get; set; }
        public int bookStock { get; set; }


        public int AuthorId { get; set; }
        public Author Author { get; set; }



        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; }


        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}