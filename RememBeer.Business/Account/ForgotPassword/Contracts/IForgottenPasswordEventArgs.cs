using Microsoft.Owin;

namespace RememBeer.Business.Account.ForgotPassword.Contracts
{
    public interface IForgottenPasswordEventArgs
    {
        IOwinContext Context { get; }

        string Email { get; }
    }
}