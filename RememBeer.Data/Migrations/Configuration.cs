using System.IO;
using System.Data.Entity.Migrations;
using System.Linq;

namespace RememBeer.Data.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<RememBeer.Data.DbContexts.RememBeerMeDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.ContextKey = "RememBeer.Data.DbContexts.RememBeerMeDbContext";
        }

        protected override void Seed(RememBeer.Data.DbContexts.RememBeerMeDbContext context)
        {
            if (context.Beers.Count() < 100)
            {
                var seedQuery = File.ReadAllText("D:\\RememBeerDbSeed.sql");
                context.Database.ExecuteSqlCommand(seedQuery);
            }
        }
    }
}
