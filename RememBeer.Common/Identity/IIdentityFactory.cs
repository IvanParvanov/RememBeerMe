using System.Data.Entity;

using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

using RememBeer.Common.Identity.Contracts;

namespace RememBeer.Common.Identity
{
    public interface IIdentityFactory
    {
        IApplicationUserManager GetApplicationUserManager(IdentityFactoryOptions<IApplicationUserManager> options, IOwinContext context, DbContext dbContext);

        IApplicationSignInManager GetApplicationSignInManager(IdentityFactoryOptions<IApplicationSignInManager> options, IOwinContext context);
    }
}
