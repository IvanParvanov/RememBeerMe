using Microsoft.Owin;

using RememBeer.Business.Account.Common.EventArcs;
using RememBeer.Business.Account.ForgotPassword.Contracts;

namespace RememBeer.Business.Account.ForgotPassword
{
    public class ForgotPasswordEventArgs : OwinContextEventArgs, IForgotPasswordEventArgs
    {
        public ForgotPasswordEventArgs(IOwinContext context, string email)
            : base(context)
        {
            this.Email = email;
        }

        public string Email { get; }
    }
}
