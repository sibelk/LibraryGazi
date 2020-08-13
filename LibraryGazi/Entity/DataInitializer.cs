using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace LibraryGazi.Entity
{
    public class DataInitializer:DropCreateDatabaseIfModelChanges<DataContext>
    {

        protected override void Seed(DataContext context)
        {
            List<Category> ct1 = new List<Category>()
            {
               
           
            };

         

           
            List<Author> au1 = new List<Author>()
            {
          

            };
         
           
            List<Publisher> pb1 = new List<Publisher>()
            {
                

            };
       


         
            List<Book> bk1 = new List<Book>()
            {
           

            };

          
            context.SaveChanges();
            base.Seed(context);
        }
    }
}