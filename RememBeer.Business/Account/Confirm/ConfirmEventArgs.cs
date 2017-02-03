using Microsoft.Owin;

using RememBeer.Business.Account.Confirm.Contracts;

namespace RememBeer.Business.Account.Confirm
{
    public class ConfirmEventArgs : IConfirmEventArgs
    {
        public ConfirmEventArgs(string userId, string code, IOwinContext context)
        {
            this.UserId = userId;
            this.Code = code;
            this.Context = context;
        }

        public IOwinContext Context { get; set; }

        public string UserId { get; set; }

        public string Code { get; set; }
    }
}
