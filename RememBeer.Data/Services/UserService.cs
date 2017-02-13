using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using RememBeer.Common.Identity.Contracts;
using RememBeer.Common.Identity.Models;
using RememBeer.Data.Repositories;
using RememBeer.Data.Services.Contracts;
using RememBeer.Models.Factories;
using RememBeer.Data.Repositories.Base;

namespace RememBeer.Data.Services
{
    public class UserService : IUserService
    {
        private readonly IModelFactory factory;
        private readonly IApplicationSignInManager signInManager;
        private readonly IApplicationUserManager userManager;
        private readonly IRepository<ApplicationUser> userRepository;

        public UserService(IApplicationUserManager userManager,
                           IApplicationSignInManager signInManager,
                           IRepository<ApplicationUser> userRepository,
                           IModelFactory factory)
        {
            if (userManager == null)
            {
                throw new ArgumentNullException(nameof(userManager));
            }

            if (factory == null)
            {
                throw new ArgumentNullException(nameof(factory));
            }

            if (signInManager == null)
            {
                throw new ArgumentNullException(nameof(signInManager));
            }

            if (userRepository == null)
            {
                throw new ArgumentNullException(nameof(userRepository));
            }

            this.signInManager = signInManager;
            this.userManager = userManager;
            this.factory = factory;
            this.userRepository = userRepository;
        }

        public IdentityResult RegisterUser(string username, string email, string password)
        {
            var user = (ApplicationUser)this.factory.CreateApplicationUser(username, email);
            var result = this.userManager.Create(user, password);

            // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
            //string code = manager.GenerateEmailConfirmationToken(user.Id);
            //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
            //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");
            return result;
        }

        public IdentityResult ChangePassword(string userId, string currentPassword, string newPassword)
        {
            var result = this.userManager.ChangePassword(userId, currentPassword, newPassword);
            if (result.Succeeded)
            {
                var user = this.userManager.FindById(userId);
                this.signInManager.SignIn(user, false, false);
            }

            return result;
        }

        public IdentityResult ConfirmEmail(string userId, string code)
        {
            return this.userManager.ConfirmEmail(userId, code);
        }

        public SignInStatus PasswordSignIn(string email, string password, bool isPersistent)
        {
            return this.signInManager.PasswordSignIn(email, password, isPersistent);
        }

        public IApplicationUser FindByName(string name)
        {
            return this.userManager.FindByName(name);
        }

        public bool IsEmailConfirmed(string userId)
        {
            return this.userManager.IsEmailConfirmed(userId);
        }

        public IEnumerable<IApplicationUser> PaginatedUsers(int currentPage, int pageSize)
        {
            return this.userRepository.All
                       .OrderBy(u => u.UserName)
                       .Skip(currentPage * pageSize)
                       .Take(pageSize)
                       .ToList();
        }

        public int CountUsers()
        {
            return this.userRepository.All.Count();
        }

        public IdentityResult DisableUser(string userId)
        {
            var result = this.userManager.UpdateSecurityStampAsync(userId).Result;
            if (!result.Succeeded)
            {
                return result;
            }

            return this.userManager.SetLockoutEndDateAsync(userId, DateTimeOffset.MaxValue).Result;
        }

        public IdentityResult EnableUser(string userId)
        {
            return this.userManager.SetLockoutEndDateAsync(userId, DateTimeOffset.MinValue).Result;
        }
    }
}
