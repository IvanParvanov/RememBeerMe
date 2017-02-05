using RememBeer.Business.Account.Confirm.Contracts;
using RememBeer.Business.Account.ForgotPassword.Contracts;
using RememBeer.Business.Account.Login.Contracts;
using RememBeer.Business.Account.ManagePassword.Contracts;

namespace RememBeer.Business.Account
{
    public interface ICustomEventArgsFactory
    {
        IConfirmEventArgs CreateConfirmEventArgs(string userId, string code);

        IForgotPasswordEventArgs CreateForgottenPasswordEventArgs(string email);

        ILoginEventArgs CreateLoginEventArgs(string email, string password, bool rememberMe);

        IChangePasswordEventArgs CreateChangePasswordEventArgs(string currentPassword,
                                                               string newPassword,
                                                               string userId);
    }
}
