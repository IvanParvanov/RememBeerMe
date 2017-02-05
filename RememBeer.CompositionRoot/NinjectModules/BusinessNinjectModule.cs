using System;
using System.Data.Entity;
using System.Linq;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
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
using RememBeer.Business.Services;
using RememBeer.Common.Identity;
using RememBeer.Common.Identity.Contracts;
using RememBeer.Common.Identity.Models;
using RememBeer.Data.DbContexts.Contracts;

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

                              return GetUserManager(options, owinContext);
                          })
                .NamedLikeFactoryMethod((IIdentityFactory f) => f.GetApplicationUserManager(null, null));

            this.Rebind<IApplicationSignInManager>()
                .ToMethod(ctx =>
                          {
                              var parameters = ctx.Parameters.ToList();
                              var options = (IdentityFactoryOptions<IApplicationSignInManager>)parameters[0]
                                  .GetValue(ctx, null);

                              var owinContext = (IOwinContext)parameters[1].GetValue(ctx, null);

                              return GetSignInManager(options, owinContext);
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

        private static IApplicationUserManager GetUserManager(IdentityFactoryOptions<IApplicationUserManager> options,
                                                              IOwinContext context)
        {
            var manager =
                new ApplicationUserManager(
                    new UserStore<ApplicationUser>((DbContext)context.Get<IRememBeerMeDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
                                    {
                                        AllowOnlyAlphanumericUserNames = false,
                                        RequireUniqueEmail = true
                                    };

            // Configure validation logic for passwords
            manager.PasswordValidator = new PasswordValidator
                                        {
                                            RequiredLength = 6,
                                            RequireNonLetterOrDigit = false,
                                            RequireDigit = false,
                                            RequireLowercase = false,
                                            RequireUppercase = false,
                                        };

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            //manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
            //                                                {
            //                                                    Subject = "Security Code",
            //                                                    BodyFormat = "Your security code is {0}"
            //                                                });

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            manager.EmailService = new EmailService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider =
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }

        public static IApplicationSignInManager GetSignInManager(IdentityFactoryOptions<IApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager((ApplicationUserManager)context.GetUserManager<IApplicationUserManager>(), context.Authentication);
        }
    }
}
