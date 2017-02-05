using System;
using System.Web;

using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

using RememBeer.Data.Identity.Contracts;

namespace RememBeer.Business.Account.Auth
{
    public class AuthFactory : IAuthFactory
    {
        public IApplicationUserManager CreateApplicationUserManager(IOwinContext context)
        {
            ThrowIfNull(context);

            return OwinContextExtensions.Get<IApplicationUserManager>(context);
        }

        public IApplicationSignInManager CreateApplicationSignInManager(IOwinContext context)
        {
            ThrowIfNull(context);

            return OwinContextExtensions.Get<IApplicationSignInManager>(context);
        }

        public IOwinContext GetOwinContext(HttpContextBase context)
        {
            return context.GetOwinContext();
        }
        
        private static void ThrowIfNull(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj));
            }
        }
    }
}
