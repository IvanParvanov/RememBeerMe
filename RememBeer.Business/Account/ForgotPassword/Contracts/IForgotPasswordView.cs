using System;
using System.Web;

using WebFormsMvp;

namespace RememBeer.Business.Account.ForgotPassword.Contracts
{
    public interface IForgotPasswordView : IView<ForgotPasswordViewModel>
    {
        event EventHandler<IForgottenPasswordEventArgs> OnForgot;

        string FailureMessage { get; set; }

        bool ErrorMessageVisible { get; set; }

        bool LoginFormVisible { get; set; }

        bool DisplayEmailVisible { get; set; }
    }
}
