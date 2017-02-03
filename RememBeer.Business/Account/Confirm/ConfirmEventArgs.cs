using Microsoft.Owin;

using RememBeer.Business.Account.Common.EventArcs;
using RememBeer.Business.Account.Confirm.Contracts;

namespace RememBeer.Business.Account.Confirm
{
    public class ConfirmEventArgs : OwinContextEventArgs, IConfirmEventArgs
    {
        public ConfirmEventArgs(IOwinContext context, string userId, string code)
            : base(context)
        {
            this.UserId = userId;
            this.Code = code;
        }

        public string UserId { get; set; }

        public string Code { get; set; }
    }
}
