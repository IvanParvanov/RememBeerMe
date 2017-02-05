﻿using System;
using System.Collections.Generic;

using RememBeer.Business.Account.Common.ViewModels;

using WebFormsMvp;

namespace RememBeer.Business.Account.ManagePassword.Contracts
{
    public interface IManagePasswordView : IView<StatelessViewModel>
    {
        event EventHandler<IChangePasswordEventArgs> ChangePassword;

        string SuccessMessage { get; set; }

        void AddErrors(IEnumerable<string> errors);
    }
}
