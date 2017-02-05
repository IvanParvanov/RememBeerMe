namespace RememBeer.Business.Account.ManagePassword.Contracts
{
    public interface IChangePasswordEventArgs
    {
        string CurrentPassword { get; set; }

        string NewPassword { get; set; }

        string UserId { get; set; }
    }
}