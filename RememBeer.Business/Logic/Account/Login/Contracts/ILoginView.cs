using System;

using RememBeer.Business.Logic.Account.Common.ViewModels;

using WebFormsMvp;

namespace RememBeer.Business.Logic.Account.Login.Contracts
{
    public interface ILoginView : IView<StatelessViewModel>
    {
        event EventHandler<ILoginEventArgs> OnLogin;

        string FailureMessage { get; set; }

        bool ErrorMessageVisible { get; set; }
    }
}
