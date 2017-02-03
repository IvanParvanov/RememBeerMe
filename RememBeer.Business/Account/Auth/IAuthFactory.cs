using Microsoft.Owin;

using RememBeer.Data;

namespace RememBeer.Business.Account.Auth
{
    public interface IAuthFactory
    {
        IApplicationUserManager CreateApplicationUserManager(IOwinContext context);
    }
}