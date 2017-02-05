using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

using RememBeer.Common.Identity.Contracts;

namespace RememBeer.Business.Account.Auth
{
    public interface IIdentityFactory
    {
        IApplicationUserManager GetApplicationUserManager(IdentityFactoryOptions<IApplicationUserManager> options, IOwinContext context);

        IApplicationSignInManager GetApplicationSignInManager(IdentityFactoryOptions<IApplicationSignInManager> options, IOwinContext context);
    }
}
