using Microsoft.Owin;

namespace RememBeer.Business.Account.Common.EventArcs.Contracts
{
    public interface IOwinContextEventArgs
    {
        IOwinContext Context { get; }
    }
}