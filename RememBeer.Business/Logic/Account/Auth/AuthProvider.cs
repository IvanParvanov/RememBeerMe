using System;
using System.Web;

using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

using RememBeer.Models.Identity.Contracts;

namespace RememBeer.Business.Logic.Account.Auth
{
    public class AuthProvider : IAuthProvider
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

        public IOwinContext CreateOwinContext(HttpContextBase context)
        {
            ThrowIfNull(context);

            return context.GetOwinContext();
        }

        private static void ThrowIfNull(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("context");
            }
        }
    }
}
