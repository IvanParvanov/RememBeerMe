using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

using RememBeer.Data.Identity.Contracts;

namespace RememBeer.Business.Account.Auth
{
    public interface IIdentityFactory
    {
        IApplicationUserManager GetApplicationUserManager(IdentityFactoryOptions<IApplicationUserManager> options, IOwinContext context);

        IApplicationSignInManager GetApplicationSignInManager(IdentityFactoryOptions<IApplicationSignInManager> options, IOwinContext context);
    }
}
