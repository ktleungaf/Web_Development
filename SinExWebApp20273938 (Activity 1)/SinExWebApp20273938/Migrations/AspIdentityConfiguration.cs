namespace SinExWebApp20273938.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    /* Directives to add to AspIdentityConfiguration.cs */
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    //using SinExWebApp20273938.Models;   //Q: Which models? Models or SinExWebApp20273938.Models?

    internal sealed class AspIdentityConfiguration : DbMigrationsConfiguration<SinExWebApp20273938.Models.ApplicationDbContext>
    {
        public AspIdentityConfiguration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SinExWebApp20273938.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //Lab06 part 1
            /* Code to add to Seed method */
            // Create Customer role.
            if (!context.Roles.Any(r => r.Name == "Customer"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Customer" };
                manager.Create(role);
            }

            // Create Employee role.
            if (!context.Roles.Any(r => r.Name == "Employee"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Employee" };
                manager.Create(role);
            }

            // Create user employee
            if (!context.Users.Any(u => u.UserName == "employee"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "employee" };
                manager.Create(user, "employee##");
                manager.AddToRole(user.Id, "Employee");
            }
        }
    }
}
