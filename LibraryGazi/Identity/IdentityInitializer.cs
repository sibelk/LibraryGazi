using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryGazi.Entity;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace LibraryGazi.Identity
{
    public class IdentityInitializer:CreateDatabaseIfNotExists<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            if (!context.Roles.Any(i => i.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name="admin", Description="admin rolü" };
                manager.Create(role);
            }

            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);
                var role = new ApplicationRole() { Name = "user", Description = "user rolü" };
                manager.Create(role);
            }

            if (!context.Users.Any(i => i.Name == "sibelkeles"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() {Name="sibel", SurName="keles", UserName="sibelkeles" , Email="sibelkeles@gmail.com" };

                manager.Create(user, "Sibelkeles18.");

                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }
            if (!context.Users.Any(i => i.Name == "hilalucdal"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser() { Name = "hilal", SurName = "üçdal", UserName = "hilalucdal", Email = "hilalucdal@gmail.com" };

                manager.Create(user, "Sibelkeles18.");
     
                manager.AddToRole(user.Id, "user");
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}