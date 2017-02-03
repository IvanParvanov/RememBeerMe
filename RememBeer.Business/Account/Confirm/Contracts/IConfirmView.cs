using System;

using WebFormsMvp;

namespace RememBeer.Business.Account.Confirm.Contracts
{
    public interface IConfirmView : IView<ConfirmViewModel>
    {
        event EventHandler<IConfirmEventArgs> OnSubmit;

        string StatusMessage { get; set; }

        bool SuccessPanelVisible { get; set; }

        bool ErrorPanelVisible { get; set; }
    }
}
