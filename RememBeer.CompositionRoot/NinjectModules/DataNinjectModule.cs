using Ninject.Modules;
using Ninject.Web.Common;

using RememBeer.Data.DbContexts;
using RememBeer.Data.DbContexts.Contracts;
using RememBeer.Data.Repositories;
using RememBeer.Data.Repositories.Contracts;
using RememBeer.Data.Services;
using RememBeer.Data.Services.Contracts;
using RememBeer.Data.Services.RankingStrategies;

namespace RememBeer.CompositionRoot.NinjectModules
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Rebind<IRememBeerMeDbContext>().To<RememBeerMeDbContext>().InRequestScope();
            this.Rebind<IRememBeerMeData>().To<RememBeerMeData>().InRequestScope();

            this.Rebind<IUserService>().To<UserService>().InRequestScope();
            this.Rebind<ITopBeersService>().To<TopBeersService>().InRequestScope();
            this.Rebind<IBeerReviewService>().To<BeerReviewService>().InRequestScope();
            this.Rebind<IBreweryService>().To<BreweryService>().InRequestScope();

            this.Bind<IBeerRankCalculationStrategy>().To<DoubleOverallScoreStrategy>().InRequestScope();
        }
    }
}