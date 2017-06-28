namespace dyplomowaApka00.Migrations
{
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using dyplomowaApka00.Models;

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
        }
    }
}
