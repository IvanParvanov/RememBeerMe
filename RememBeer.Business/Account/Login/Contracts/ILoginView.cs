using System;

using RememBeer.Business.Account.Common.ViewModels;

using WebFormsMvp;

namespace RememBeer.Business.Account.Login.Contracts
{
    public interface ILoginView : IView<StatelessViewModel>
    {
        event EventHandler<ILoginEventArgs> OnLogin;

        string FailureMessage { get; set; }

        bool ErrorMessageVisible { get; set; }
    }
}
