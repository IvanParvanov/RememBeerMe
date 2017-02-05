using RememBeer.Business.Account.Confirm.Contracts;

namespace RememBeer.Business.Account.Confirm
{
    public class ConfirmEventArgs : IConfirmEventArgs
    {
        public ConfirmEventArgs(string userId, string code)
        {
            this.UserId = userId;
            this.Code = code;
        }

        public string UserId { get; set; }

        public string Code { get; set; }
    }
}
