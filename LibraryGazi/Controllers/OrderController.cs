using LibraryGazi.Entity;
using LibraryGazi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryGazi.Controllers
{
    [Authorize(Roles ="admin")]
    public class OrderController : Controller
    {
        DataContext db = new DataContext();
        // GET: Order
        public ActionResult Index()
        {
            var orders = db.Orders.Select(i => new AdminOrderModel()
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                AlisTarihi = i.AlisTarihi,
                VerisTarihi = i.VerisTarihi,
                Count = i.OrderLines.Count()

            }).OrderByDescending(i=>i.OrderDate).ToList();
            return View(orders);
        }
        public ActionResult Details(int id)
        {

            var entity = db.Orders.Where(i => i.Id == id).Select(i => new OrderDetailsModel()
            {
                OrderId = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                OrderState = i.OrderState,
                AlisTarihi = i.AlisTarihi,
                VerisTarihi = i.VerisTarihi,
                UserName=i.UserName,
                OrderLines = i.OrderLines.Select(a => new OrderLineModel()
                {
                    BookId = a.BookId,
                    BookName = a.Book.bookName

                }).ToList()



            }).FirstOrDefault();

            return View(entity);
        }
        public ActionResult UpdateOrderState(int OrderId, EnumOrderState OrderState)
        {
            var order = db.Orders.FirstOrDefault(i => i.Id == OrderId);
            if (order!=null)
            {
                order.OrderState = OrderState;
                db.SaveChanges();
                TempData["message"] = "Bilgiler Kaydedildi.";
                return RedirectToAction("Details", new { id = OrderId });
            }
            return RedirectToAction("Index");
        }
    }
}