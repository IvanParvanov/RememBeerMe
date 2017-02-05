using RememBeer.Business.Account.Common.EventArcs.Contracts;

namespace RememBeer.Business.Account.ManagePassword.Contracts
{
    public interface IChangePasswordEventArgs : IOwinContextEventArgs
    {
        string CurrentPassword { get; set; }

        string NewPassword { get; set; }

        string UserId { get; set; }
    }
}