using LibraryGazi.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LibraryGazi.Models;

namespace LibraryGazi.Controllers
{
   
    public class CartController : Controller
    {

        private DataContext db = new DataContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }
        public ActionResult AddToCart(int Id)
        {
            var book = db.Books.FirstOrDefault(i => i.Id == Id);
            if (book != null && book.bookStock >0)
            {
                GetCart().AddBook(book);
            }
            return RedirectToAction("Index");
        }
        public ActionResult RemoveFromCart(int Id)
        {
            var book = db.Books.FirstOrDefault(i => i.Id == Id);
            if (book != null)
            {
                GetCart().DeleteBook(book);
            }
            return RedirectToAction("Index");
        }
        public Card GetCart(){



           var cart= (Card)Session["Cart"];
            if (cart == null)
            {
                cart = new Card();
                Session["Cart"] = cart;

            }
            return cart;
         }
        public PartialViewResult Summary()
        {
            return PartialView(GetCart());
        }
        public ActionResult Checkout()
        {
            return View(new RequestDetails());
        }
        [HttpPost]
        public ActionResult Checkout(RequestDetails entity)
        {
            var cart = GetCart();
            if (cart.CartLines.Count==0)
            {
                ModelState.AddModelError("KitapYokError", "İstek Spetinde kitap yok");
            }
            if (ModelState.IsValid)
            {
                SaveOrder(cart,entity);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(entity);
            }
            return View();
        }

        private void SaveOrder(Card cart, RequestDetails entity)
        {
            var order = new Order();
            order.OrderNumber = (new Random()).Next(11111, 99999).ToString();
            order.OrderDate = DateTime.Now;
            order.UserName = User.Identity.Name;
            order.AlisTarihi = entity.alisTarihi;
            order.VerisTarihi = entity.verisTarihi;
            order.OrderState = EnumOrderState.Bekleniyor;

            order.OrderLines = new List<OrderLine>();
            foreach (var item in cart.CartLines)
            {
                OrderLine orderline = new OrderLine();
                orderline.BookId = item.Book.Id;
                order.OrderLines.Add(orderline);
                //item.Book.bookStock = item.Book.bookStock - 1;
               


            }
            db.Orders.Add(order);
            db.SaveChanges();
        
        }
    }
}