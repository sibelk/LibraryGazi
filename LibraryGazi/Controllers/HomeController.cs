using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using LibraryGazi.Entity;

namespace LibraryGazi.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    

        DataContext _context= new DataContext();


        public ActionResult AramaSonuc()
        {
           

            return View();
        }
        public PartialViewResult kitapGetir(string arama)
        {
            var kitaplar = from s in _context.Books.Include("Category").Include("Publisher").Include("Author")
                      
            select s;

            if (!string.IsNullOrEmpty(arama))
            {
              
                kitaplar = kitaplar.Where(s => s.bookName.Contains(arama));
             
            }
            return PartialView(kitaplar.ToList());
        }
        public ActionResult Hakkinda()
        {
            return View();
        }
        public ActionResult Sartlar()
        {
            return View();
        }
        public ActionResult İletisim()
        {
            return View();
        }
        [Authorize]
        public ActionResult kitapayirtüye()
        {
            return View();
        }

        [Authorize]
        public PartialViewResult KitapAyirt(string ayirt)
        {

            //session yoksagiriş sayfasına yönlerndir.
            var kitaplar = from s in _context.Books.Include("Category").Include("Publisher").Include("Author")
                           select s;
            if (!string.IsNullOrEmpty(ayirt))
            {
                //buraya if ekle select list ten gelen arama kriteri değerine göre kitaplar = kitaplar.Where(s => s.bookName.Contains(ayirt)); de bookName yerine yazar vs yaz.
                kitaplar = kitaplar.Where(s => s.bookName.Contains(ayirt));
            }

            return PartialView(kitaplar.ToList());
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            return View(_context.Books.Include("Category").Include("Author").Include("Publisher").Where(i=>i.Id==id).FirstOrDefault());
        }

    }
}