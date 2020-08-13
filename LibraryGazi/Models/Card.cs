using LibraryGazi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LibraryGazi.Models
{
    public class Card
    {
        private List<Cartline> cartLines = new List<Cartline>();

        public List<Cartline> CartLines
        {
            get { return cartLines; }
        }
        public void AddBook(Book book)
        {
            var line = cartLines.FirstOrDefault(i => i.Book.Id == book.Id);
            if (line==null)
            {
                cartLines.Add(new Cartline() { Book = book });
            }
            else
            {
                //modal ekle aynı kitaptan bi tane alblirsin de
            }
        }
        public void DeleteBook(Book book)
        {
            CartLines.RemoveAll(i => i.Book.Id==book.Id);
        }
        public void Clear()
        {
            CartLines.Clear();
        }


    }
    public class Cartline
    {
        public Book Book { get; set; }
      
    }
}