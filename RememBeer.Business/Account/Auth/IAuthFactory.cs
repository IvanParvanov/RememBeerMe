using Microsoft.Owin;

using RememBeer.Data.Identity.Contracts;

namespace RememBeer.Business.Account.Auth
{
    public interface IAuthFactory
    {
        IApplicationUserManager CreateApplicationUserManager(IOwinContext context);

        IApplicationSignInManager CreateApplicationSignInManager(IOwinContext context);
    }
}