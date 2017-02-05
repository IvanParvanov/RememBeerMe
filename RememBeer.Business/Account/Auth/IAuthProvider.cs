using System.Web;

using Microsoft.Owin;

using RememBeer.Common.Identity.Contracts;

namespace RememBeer.Business.Account.Auth
{
    public interface IAuthProvider
    {
        IApplicationUserManager CreateApplicationUserManager(IOwinContext context);

        IApplicationSignInManager CreateApplicationSignInManager(IOwinContext context);

        IOwinContext CreateOwinContext(HttpContextBase context);
    }
}