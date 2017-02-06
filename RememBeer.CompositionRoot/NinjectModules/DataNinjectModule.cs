using Ninject.Modules;
using Ninject.Web.Common;

using RememBeer.Data.Repositories;
using RememBeer.Data.Repositories.Contracts;
using RememBeer.Data.Services;

namespace RememBeer.CompositionRoot.NinjectModules
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IRememBeerMeData>().To<RememBeerMeData>();
            this.Bind<IBeersData>().To<RememBeerMeData>();
            this.Bind<IBeerReviewsData>().To<RememBeerMeData>();
            this.Bind<IBeerTypesData>().To<RememBeerMeData>();
            this.Bind<IBreweriesData>().To<RememBeerMeData>();
            this.Bind<IUserData>().To<RememBeerMeData>();

            this.Rebind<IUserService>().To<UserService>().InRequestScope();
        }
    }
}