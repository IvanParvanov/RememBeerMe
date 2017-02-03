using Microsoft.Owin;

using RememBeer.Business.Account.Common.EventArcs.Contracts;

namespace RememBeer.Business.Account.Login.Contracts
{
    public interface ILoginEventArgs : IOwinContextEventArgs
    {
        string Email { get; }
        string Password { get; }
        bool RememberMe { get; }
    }
}
