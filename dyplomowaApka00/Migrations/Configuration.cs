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
                var user = new ApplicationUser { UserName = "kontakt@ablab.pl", Email = "kontakt@ablab.pl" };
                manager.Create(user, "1Ha5/0");
                manager.AddToRole(user.Id, "Admin");
            }
        }
    }
}
