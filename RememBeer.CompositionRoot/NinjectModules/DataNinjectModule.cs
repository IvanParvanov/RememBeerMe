using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Web.Common;

using RememBeer.Business.Services;
using RememBeer.Business.Services.Contracts;
using RememBeer.Business.Services.RankingStrategies;
using RememBeer.Business.Services.RankingStrategies.Contracts;
using RememBeer.Common.Cache;
using RememBeer.Common.Constants;
using RememBeer.Data.DbContexts;
using RememBeer.Data.DbContexts.Contracts;
using RememBeer.Data.Repositories;
using RememBeer.Models.Factories;

namespace RememBeer.CompositionRoot.NinjectModules
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Rebind<IRememBeerMeDbContext>().To<RememBeerMeDbContext>().InRequestScope();

            this.Rebind<IUserService>().To<UserService>().InRequestScope();
            this.Rebind<ITopBeersService>().To<TopBeersService>().InRequestScope();
            this.Rebind<IBeerReviewService>().To<BeerReviewService>().InRequestScope();
            this.Rebind<IBreweryService>().To<BreweryService>().InRequestScope();

            this.Rebind<IModelFactory>().To<ModelFactory>().InSingletonScope();
            this.Bind<IRankFactory>().To<ModelFactory>().InSingletonScope();

            this.Bind<IRankCalculationStrategy>().To<DoubleOverallScoreStrategy>().InRequestScope();

            this.Bind<IDataModifiedResultFactory>().ToFactory().InSingletonScope();

            this.Rebind<ICacheManager>()
                .ToMethod(context => new CacheManager(Constants.DefaultCacheDurationInMinutes))
                .InSingletonScope();
        }
    }
}
