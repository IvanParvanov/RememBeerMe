using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

using RememBeer.Data;

namespace RememBeer.Business.Account.Auth
{
    public interface IIdentityFactory
    {
        ApplicationUserManager GetApplicationUserManager(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context);
    }
}
