using System;

using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

using RememBeer.Data;

namespace RememBeer.Business.Account.Auth
{
    public class AuthFactory : IAuthFactory
    {
        public IApplicationUserManager CreateApplicationUserManager(IOwinContext ctx)
        {
            if (ctx == null)
            {
                throw new ArgumentNullException(nameof(ctx));
            }

            return ctx.Get<ApplicationUserManager>();
        }
    }
}
