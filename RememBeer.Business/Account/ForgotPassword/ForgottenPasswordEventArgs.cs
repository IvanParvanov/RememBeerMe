using System;

using Microsoft.Owin;

using RememBeer.Business.Account.ForgotPassword.Contracts;

namespace RememBeer.Business.Account.ForgotPassword
{
    public class ForgottenPasswordEventArgs : EventArgs, IForgottenPasswordEventArgs
    {
        public ForgottenPasswordEventArgs(IOwinContext context, string email)
        {
            this.Context = context;
            this.Email = email;
        }

        public IOwinContext Context { get; }

        public string Email { get; }
    }
}