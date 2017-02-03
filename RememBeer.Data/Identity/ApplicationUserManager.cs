using System;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

using RememBeer.Data.DbContexts;
using RememBeer.Data.Identity.Contracts;
using RememBeer.Data.Identity.Models;

namespace RememBeer.Data.Identity
{
    public class ApplicationUserManager : UserManager<ApplicationUser>, IApplicationUserManager
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
        }

        public static IApplicationUserManager Create(IdentityFactoryOptions<IApplicationUserManager> options, IOwinContext context)
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<RememBeerMeDbContext>()));
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
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
                                                            {
                                                                MessageFormat = "Your security code is {0}"
                                                            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
                                                            {
                                                                Subject = "Security Code",
                                                                BodyFormat = "Your security code is {0}"
                                                            });

            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            manager.EmailService = new EmailService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }

        public virtual IdentityResult ConfirmEmail(string userId, string token)
        {
            return UserManagerExtensions.ConfirmEmail(this, userId, token);
        }

        public virtual bool IsEmailConfirmed(string userId)
        {
            return UserManagerExtensions.IsEmailConfirmed(this, userId);
        }

        public virtual ApplicationUser FindByName(string email)
        {
            return UserManagerExtensions.FindByName(this, email);
        }

        public virtual bool HasPassword(string userId)
        {
            return UserManagerExtensions.HasPassword(this, userId);
        }

        public virtual IdentityResult Create(ApplicationUser user, string password)
        {
            return UserManagerExtensions.Create(this, user, password);
        }

        public virtual ApplicationUser FindById(string userId)
        {
            return UserManagerExtensions.FindById(this, userId);

        }

        public virtual IdentityResult AddPassword(string userId, string password)
        {
            return UserManagerExtensions.AddPassword(this, userId, password);
        }

        public virtual IdentityResult ChangePassword(string userId, string currentPassword, string newPassword)
        {
            return UserManagerExtensions.ChangePassword(this, userId, currentPassword, newPassword);
        }
    }
}