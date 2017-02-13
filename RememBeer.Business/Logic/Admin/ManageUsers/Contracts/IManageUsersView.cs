using System;

using RememBeer.Business.Logic.Common.Contracts;
using RememBeer.Business.Logic.Common.EventArgs.Contracts;

namespace RememBeer.Business.Logic.Admin.ManageUsers.Contracts
{
    public interface IManageUsersView : IInitializableView<ManageUsersViewModel>,
                                        IViewWithErrors,
                                        IViewWithSuccess,
                                        IPaginatedView
    {
        event EventHandler<IIdentifiableEventArgs<string>> UserDisable;

        event EventHandler<IIdentifiableEventArgs<string>> UserEnable;

        event EventHandler<IIdentifiableEventArgs<string>> UserMakeAdmin;

        event EventHandler UserUpdate;

        event EventHandler UserSearch;
    }
}
