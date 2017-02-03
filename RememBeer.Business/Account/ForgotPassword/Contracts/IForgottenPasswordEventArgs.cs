using RememBeer.Business.Account.Common.EventArcs.Contracts;

namespace RememBeer.Business.Account.ForgotPassword.Contracts
{
    public interface IForgottenPasswordEventArgs : IOwinContextEventArgs
    {
        string Email { get; }
    }
}