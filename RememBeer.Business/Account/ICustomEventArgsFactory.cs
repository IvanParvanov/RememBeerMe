using Microsoft.Owin;

using RememBeer.Business.Account.Confirm.Contracts;
using RememBeer.Business.Account.ForgotPassword.Contracts;
using RememBeer.Business.Account.Login.Contracts;
using RememBeer.Business.Account.ManagePassword.Contracts;

namespace RememBeer.Business.Account
{
    public interface ICustomEventArgsFactory
    {
        IConfirmEventArgs CreateConfirmEventArgs(IOwinContext context, string userId, string code);

        IForgotPasswordEventArgs CreateForgottenPasswordEventArgs(IOwinContext context, string email);

        ILoginEventArgs CreateLoginEventArgs(IOwinContext context, string email, string password, bool rememberMe);

        IChangePasswordEventArgs CreateChangePasswordEventArgs(IOwinContext context,
                                                               string currentPassword,
                                                               string newPassword,
                                                               string userId);
    }
}
