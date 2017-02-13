using System;

using RememBeer.Business.Logic.Account.Common.ViewModels;

using WebFormsMvp;

namespace RememBeer.Business.Logic.Account.Confirm.Contracts
{
    public interface IConfirmView : IView<StatelessViewModel>
    {
        event EventHandler<IConfirmEventArgs> OnSubmit;

        string StatusMessage { get; set; }

        bool SuccessPanelVisible { get; set; }

        bool ErrorPanelVisible { get; set; }
    }
}
