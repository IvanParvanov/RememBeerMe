using RememBeer.Business.Account.Common.EventArcs.Contracts;

namespace RememBeer.Business.Account.ForgotPassword.Contracts
{
    public interface IForgotPasswordEventArgs : IOwinContextEventArgs
    {
        string Email { get; }
    }
}