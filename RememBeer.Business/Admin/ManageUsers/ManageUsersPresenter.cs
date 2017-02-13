using System;

using RememBeer.Business.Account.Common.Presenters;
using RememBeer.Business.Admin.ManageUsers.Contracts;
using RememBeer.Business.Common.EventArgs.Contracts;
using RememBeer.Data.Services.Contracts;

namespace RememBeer.Business.Admin.ManageUsers
{
    public class ManageUsersPresenter : UserServicePresenter<IManageUsersView>
    {
        public ManageUsersPresenter(IUserService userService, IManageUsersView view)
            : base(userService, view)
        {
            this.View.UserUpdate += this.OnViewUpdateUser;
            this.View.UserMakeAdmin += this.OnViewMakeAdmin;
            this.View.UserDisable += this.OnViewDisableUser;
            this.View.UserEnable += this.OnViewEnableUser;
            this.View.Initialized += this.OnViewInitialized;
        }

        private void OnViewInitialized(object sender, EventArgs e)
        {
            var currentPage = this.View.CurrentPage;
            var pageSize = this.View.PageSize;

            var users = this.UserService.PaginatedUsers(currentPage, pageSize);
            this.View.TotalPages = this.UserService.CountUsers();
            this.View.Model.Users = users;
        }

        private void OnViewDisableUser(object sender, IIdentifiableEventArgs<string> e)
        {
            var result = this.UserService.DisableUser(e.Id);
            if (result.Succeeded)
            {
                this.SetSuccess("User locked out!");
            }
            else
            {
                this.SetError(string.Join(", ", result.Errors));
            }
        }

        private void OnViewEnableUser(object sender, IIdentifiableEventArgs<string> e)
        {
            var result = this.UserService.EnableUser(e.Id);
            if (result.Succeeded)
            {
                this.SetSuccess("User has been enabled!");
            }
            else
            {
                this.SetError(string.Join(", ", result.Errors));
            }
        }

        private void OnViewUpdateUser(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnViewMakeAdmin(object sender, IIdentifiableEventArgs<string> e)
        {
            throw new NotImplementedException();
        }

        private void SetError(string error)
        {
            this.View.ErrorMessageText = error;
            this.View.ErrorMessageVisible = true;
        }

        private void SetSuccess(string message)
        {
            this.View.SuccessMessageText = message;
            this.View.SuccessMessageVisible = true;
        }
    }
}
