using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using RememBeer.Common.Identity.Contracts;

namespace RememBeer.Common.Identity.Models
{
    public class ApplicationUser : IdentityUser, IApplicationUser
    {
        public virtual ClaimsIdentity GenerateUserIdentity(IApplicationUserManager manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public virtual Task<ClaimsIdentity> GenerateUserIdentityAsync(IApplicationUserManager manager)
        {
            return Task.FromResult(this.GenerateUserIdentity(manager));
        }
    }
}