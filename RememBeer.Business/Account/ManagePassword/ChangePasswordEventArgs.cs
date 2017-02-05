using Microsoft.Owin;

using RememBeer.Business.Account.Common.EventArcs;
using RememBeer.Business.Account.ManagePassword.Contracts;

namespace RememBeer.Business.Account.ManagePassword
{
    public class ChangePasswordEventArgs : OwinContextEventArgs, IChangePasswordEventArgs
    {
        public ChangePasswordEventArgs(IOwinContext context, string currentPassword, string newPassword, string userId)
            : base(context)
        {
            this.CurrentPassword = currentPassword;
            this.NewPassword = newPassword;
            this.UserId = userId;
        }

        public string CurrentPassword { get; set; }

        public string NewPassword { get; set; }

        public string UserId { get; set; }
    }
}
