namespace dyplomowaApka00.Migrations
{
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using dyplomowaApka00.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<dyplomowaApka00.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(dyplomowaApka00.Models.ApplicationDbContext context)
        {
            /*context.Statusy.AddOrUpdate(
                s => s.StatusId,
                new Status { StatusId = 1, Nazwa = "Wolne" },
                new Status { StatusId = 2, Nazwa = "Sprzedane" },
                new Status { StatusId = 3, Nazwa = "Rezerwacja" },
                new Status { StatusId = 4, Nazwa = "Pokazowe" },
                );
            context.Inwestycje.AddOrUpdate(
                i => i.InwestycjaId,
                new Inwestycja { InwestycjaId = 1, Nazwa = "Osiedle Lutynia" },
                new Inwestycja { InwestycjaId = 2, Nazwa = "Osiedle Krzeptów" },
                );*/

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
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };
                manager.Create(role);
            }
            if (!context.Users.Any(u => u.UserName == "kontakt@ablab.pl"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "kontakt@ablab.pl" };
                manager.Create(user, "1Ha5/0");
                manager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
