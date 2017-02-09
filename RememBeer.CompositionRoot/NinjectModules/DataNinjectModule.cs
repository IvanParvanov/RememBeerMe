using Ninject.Modules;
using Ninject.Web.Common;

using RememBeer.Business.Services;
using RememBeer.Business.Services.Contracts;
using RememBeer.Data.Repositories;
using RememBeer.Data.Repositories.Contracts;

namespace RememBeer.CompositionRoot.NinjectModules
{
    public class DataNinjectModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IRememBeerMeData>().To<RememBeerMeData>().InRequestScope();
            this.Bind<IBeersData>().To<RememBeerMeData>().InRequestScope();
            this.Bind<IBeerReviewsData>().To<RememBeerMeData>().InRequestScope();
            this.Bind<IBeerTypesData>().To<RememBeerMeData>().InRequestScope();
            this.Bind<IBreweriesData>().To<RememBeerMeData>().InRequestScope();
            this.Bind<IUserData>().To<RememBeerMeData>().InRequestScope();

            this.Rebind<IUserService>().To<UserService>().InRequestScope();
        }
    }
}