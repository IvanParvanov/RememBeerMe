using System;

using RememBeer.Business.Common.Contracts;
using RememBeer.Business.Common.EventArgs.Contracts;

namespace RememBeer.Business.Admin.ManageUsers.Contracts
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
