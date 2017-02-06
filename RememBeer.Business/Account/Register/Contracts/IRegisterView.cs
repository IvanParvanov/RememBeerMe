using System;

using RememBeer.Business.Account.Common.ViewModels;

using WebFormsMvp;

namespace RememBeer.Business.Account.Register.Contracts
{
    public interface IRegisterView : IView<StatelessViewModel>
    {
        event EventHandler<IRegisterEventArgs> OnRegister;
         
        string ErrorMessageText { get; set; }
    }
}