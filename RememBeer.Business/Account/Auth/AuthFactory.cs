using System;

using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

using RememBeer.Data;

namespace RememBeer.Business.Account.Auth
{
    public class AuthFactory : IAuthFactory
    {
        public IApplicationUserManager CreateApplicationUserManager(IOwinContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            return OwinContextExtensions.Get<IApplicationUserManager>(context);
        }
    }
}
