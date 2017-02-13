using System.Web;

using Microsoft.Owin;

using RememBeer.Common.Identity.Contracts;

namespace RememBeer.Business.Logic.Account.Auth
{
    public interface IAuthProvider
    {
        IApplicationUserManager CreateApplicationUserManager(IOwinContext context);

        IApplicationSignInManager CreateApplicationSignInManager(IOwinContext context);

        IOwinContext CreateOwinContext(HttpContextBase context);
    }
}