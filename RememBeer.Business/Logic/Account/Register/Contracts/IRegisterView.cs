using System;

using RememBeer.Business.Logic.Account.Common.ViewModels;

using WebFormsMvp;

namespace RememBeer.Business.Logic.Account.Register.Contracts
{
    public interface IRegisterView : IView<StatelessViewModel>
    {
        event EventHandler<IRegisterEventArgs> OnRegister;

        string ErrorMessageText { get; set; }
    }
}
