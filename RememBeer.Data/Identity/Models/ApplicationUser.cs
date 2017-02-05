using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

using RememBeer.Data.Identity.Contracts;

namespace RememBeer.Data.Identity.Models
{
    public interface IApplicationUser : IUser<string>
    {
        ClaimsIdentity GenerateUserIdentity(IApplicationUserManager manager);

        Task<ClaimsIdentity> GenerateUserIdentityAsync(IApplicationUserManager manager);

        string Email { get; set; }

        bool EmailConfirmed { get; set; }

        string PasswordHash { get; set; }

        string SecurityStamp { get; set; }

        string PhoneNumber { get; set; }

        bool PhoneNumberConfirmed { get; set; }

        bool TwoFactorEnabled { get; set; }

        DateTime? LockoutEndDateUtc { get; set; }

        bool LockoutEnabled { get; set; }

        int AccessFailedCount { get; set; }

        ICollection<IdentityUserRole> Roles { get; }

        ICollection<IdentityUserClaim> Claims { get; }

        ICollection<IdentityUserLogin> Logins { get; }
    }

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