using LibraryGazi.Entity;
using LibraryGazi.Identity;
using LibraryGazi.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace LibraryGazi.Controllers
{
    public class AccountController : Controller
    {
        public DataContext db = new DataContext();

        [Authorize]
        public ActionResult Index()
        {
            var username = User.Identity.Name;
            var orders = db.Orders.Where(i => i.UserName == username).Select(i => new UserOrderModel()
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderDate = i.OrderDate,
                AlisTarihi = i.AlisTarihi,
                VerisTarihi = i.VerisTarihi,
                OrderState = i.OrderState,


            }).OrderByDescending(i=>i.OrderDate).ToList(); // istekler tarihe göre azalanoalarak sıralanacak
            return View(orders);
           

        }
        [Authorize]
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
                OrderLines = i.OrderLines.Select(a => new OrderLineModel()
                {
                    BookId = a.BookId,
                    BookName=a.Book.bookName

                }).ToList()



            }).FirstOrDefault();

            return View(entity);
        }
    private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;
        public AccountController()
        {
           var userStore = new UserStore<ApplicationUser>(new IdentityDataContext());
            UserManager = new UserManager<ApplicationUser>(userStore);
            var roleStore = new RoleStore<ApplicationRole>(new IdentityDataContext());
            RoleManager = new RoleManager<ApplicationRole>(roleStore);
        }

       
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.Name = model.Name;
                user.SurName = model.SurName;
                user.Email = model.Email;


               IdentityResult result= UserManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    if (RoleManager.RoleExists("user"))
                    {
                        UserManager.AddToRole(user.Id, "user");
                    }
                    return RedirectToAction("Login", "Account");
                }
               else
                {
                    ModelState.AddModelError("RegisterUserError","Kullanıcı oluşturma hatası.");
                }
                    
            }

            return View();
        }




        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login model,string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                //login
               var user= UserManager.Find(model.UserName, model.Password);

                if (user != null)
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identityclaims = UserManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties();
                   authProperties.IsPersistent= model.RememberMe;
                    authManager.SignIn(authProperties,identityclaims);
                    
                    

                    if (!String.IsNullOrEmpty(ReturnUrl))
                    {
                       return  Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Hatalı giriş.");
                }
            }

            return View(model);
        }
        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();
            return RedirectToAction("Index", "Home");

        }
    }
}