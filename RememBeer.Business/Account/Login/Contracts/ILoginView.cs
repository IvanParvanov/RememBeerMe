using System;

using WebFormsMvp;

namespace RememBeer.Business.Account.Login.Contracts
{
    public interface ILoginView : IView<LoginViewModel>
    {
        event EventHandler<ILoginEventArgs> OnLogin;
    }
}
