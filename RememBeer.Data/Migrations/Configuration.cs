using System.IO;
using System.Data.Entity.Migrations;
using System.Linq;

using Microsoft.AspNet.Identity.EntityFramework;

namespace RememBeer.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<RememBeer.Data.DbContexts.RememBeerMeDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationDataLossAllowed = true;
            this.AutomaticMigrationsEnabled = true;
            this.ContextKey = "RememBeer.Data.DbContexts.RememBeerMeDbContext";
        }

        protected override void Seed(RememBeer.Data.DbContexts.RememBeerMeDbContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.Add(new IdentityRole("Admin"));
            }

            context.SaveChanges();
        }
    }
}
