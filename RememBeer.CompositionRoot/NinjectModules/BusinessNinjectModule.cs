using System;
using System.Linq;

using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Parameters;

using RememBeer.Business.Account;
using RememBeer.Business.Account.Auth;
using RememBeer.Business.MvpPresenterFactory;
using RememBeer.Data.Identity;
using RememBeer.Data.Identity.Contracts;
using RememBeer.Data.Identity.Models;

using WebFormsMvp;
using WebFormsMvp.Binder;

namespace RememBeer.CompositionRoot.NinjectModules
{
    public class BusinessNinjectModule : NinjectModule
    {
        /// <summary>Loads the module into the kernel.</summary>
        public override void Load()
        {
            this.Bind<IPresenterFactory>().To<MvpPresenterFactory>().InSingletonScope();

            this.Bind<IMvpPresenterFactory>().ToFactory().InSingletonScope();

            this.Bind<ICustomEventArgsFactory>().ToFactory().InSingletonScope();

            this.Bind<IPresenter>()
                .ToMethod(GetPresenter)
                .NamedLikeFactoryMethod(
                                        (IMvpPresenterFactory factory) => factory.GetPresenter(null, null)
                );

            this.Bind<IIdentityFactory>().ToFactory();

            this.Rebind<IApplicationUserManager>()
                .ToMethod(ctx =>
                          {
                              var parameters = ctx.Parameters.ToList();
                              var options = (IdentityFactoryOptions<IApplicationUserManager>)parameters[0]
                                  .GetValue(ctx, null);

                              var owinContext = (IOwinContext)parameters[1].GetValue(ctx, null);

                              return ApplicationUserManager.Create(options, owinContext);
                          })
                .NamedLikeFactoryMethod((IIdentityFactory f) => f.GetApplicationUserManager(null, null));

            this.Rebind<IApplicationSignInManager>()
                .ToMethod(ctx =>
                {
                    var parameters = ctx.Parameters.ToList();
                    var options = (IdentityFactoryOptions<IApplicationSignInManager>)parameters[0]
                        .GetValue(ctx, null);

                    var owinContext = (IOwinContext)parameters[1].GetValue(ctx, null);

                    return ApplicationSignInManager.Create(options, owinContext);
                })
                .NamedLikeFactoryMethod((IIdentityFactory f) => f.GetApplicationSignInManager(null, null));

            this.Rebind<IIdentityHelper>().To<IdentityHelper>().InSingletonScope();
        }

        private static IPresenter GetPresenter(IContext context)
        {
            var parameters = context.Parameters.ToList();

            var presenterType = (Type)parameters[0].GetValue(context, null);
            var viewInstance = (IView)parameters[1].GetValue(context, null);

            var ctorParamter = new ConstructorArgument("view", viewInstance);

            return (IPresenter)context.Kernel.Get(presenterType, ctorParamter);
        }
    }
}
