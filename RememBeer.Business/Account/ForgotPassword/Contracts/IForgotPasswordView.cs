using System;

using RememBeer.Business.Account.Common.ViewModels;

using WebFormsMvp;

namespace RememBeer.Business.Account.ForgotPassword.Contracts
{
    public interface IForgotPasswordView : IView<StatelessViewModel>
    {
        event EventHandler<IForgotPasswordEventArgs> OnForgot;

        string FailureMessage { get; set; }

        bool ErrorMessageVisible { get; set; }

        bool LoginFormVisible { get; set; }

        bool DisplayEmailVisible { get; set; }
    }
}
