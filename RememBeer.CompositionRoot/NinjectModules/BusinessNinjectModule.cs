using System;
using System.Linq;
using System.Web;

using Ninject;
using Ninject.Activation;
using Ninject.Extensions.Factory;
using Ninject.Modules;
using Ninject.Parameters;

using RememBeer.Business.Logic.Account.Auth;
using RememBeer.Business.Logic.Common;
using RememBeer.Business.Logic.MvpPresenterFactory;
using RememBeer.Common.Configuration;
using RememBeer.Common.Identity;
using RememBeer.Common.Identity.Contracts;
using RememBeer.Common.Services;
using RememBeer.Common.Services.Contracts;

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

            this.Rebind<IIdentityHelper>().To<IdentityHelper>().InSingletonScope();
            this.Rebind<IConfigurationProvider>().To<ConfigurationProvider>().InSingletonScope();

            this.Rebind<IApplicationSignInManager>().ToMethod((context) =>
                                                              {
                                                                  var cbase = new HttpContextWrapper(HttpContext.Current);
                                                                  var f = context.Kernel.Get<IAuthProvider>();
                                                                  var owinCtx = f.CreateOwinContext(cbase);

                                                                  return f.CreateApplicationSignInManager(owinCtx);
                                                              });

            this.Rebind<IApplicationUserManager>().ToMethod((context) =>
                                                            {
                                                                var cbase = new HttpContextWrapper(HttpContext.Current);
                                                                var f = context.Kernel.Get<IAuthProvider>();
                                                                var owinCtx = f.CreateOwinContext(cbase);

                                                                return f.CreateApplicationUserManager(owinCtx);
                                                            });

            this.Bind<IImageUploadService>().To<CloudinaryImageUpload>();
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
