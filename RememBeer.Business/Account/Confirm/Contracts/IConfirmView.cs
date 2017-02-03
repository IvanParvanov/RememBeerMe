using System;

using RememBeer.Business.Account.Common.ViewModels;

using WebFormsMvp;

namespace RememBeer.Business.Account.Confirm.Contracts
{
    public interface IConfirmView : IView<StatelessViewModel>
    {
        event EventHandler<IConfirmEventArgs> OnSubmit;

        string StatusMessage { get; set; }

        bool SuccessPanelVisible { get; set; }

        bool ErrorPanelVisible { get; set; }
    }
}
