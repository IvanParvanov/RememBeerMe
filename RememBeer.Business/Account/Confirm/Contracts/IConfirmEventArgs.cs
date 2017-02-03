using Microsoft.Owin;

namespace RememBeer.Business.Account.Confirm.Contracts
{
    public interface IConfirmEventArgs
    {
        string UserId { get; set; }

        string Code { get; set; }

        IOwinContext Context { get; set; }
    }
}