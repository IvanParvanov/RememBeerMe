using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;

using RememBeer.Data.Identity.Contracts;
using RememBeer.Data.Identity.Models;

namespace RememBeer.Data.Identity
{
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>, IApplicationSignInManager
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)this.UserManager);
        }

        public static IApplicationSignInManager Create(IdentityFactoryOptions<IApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager((ApplicationUserManager)context.GetUserManager<IApplicationUserManager>(), context.Authentication);
        }

        public virtual SignInStatus PasswordSignIn(string email, string password, bool isPersistent)
        {
            return SignInManagerExtensions.PasswordSignIn(this, email, password, isPersistent, true);
        }

        public virtual void SignIn(ApplicationUser user, bool isPersistent, bool rememberBrowser)
        {
            SignInManagerExtensions.SignIn(this, user, isPersistent, rememberBrowser);
        }
    }
}