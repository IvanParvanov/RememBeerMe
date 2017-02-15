using System;
using System.Collections.Generic;

using RememBeer.Business.Logic.Account.Common.Presenters;
using RememBeer.Business.Logic.Admin.ManageUsers.Contracts;
using RememBeer.Business.Logic.Common.EventArgs.Contracts;
using RememBeer.Business.Services.Contracts;
using RememBeer.Common.Identity.Contracts;

namespace RememBeer.Business.Logic.Admin.ManageUsers
{
    public class ManageUsersPresenter : UserServicePresenter<IManageUsersView>
    {
        public ManageUsersPresenter(IUserService userService, IManageUsersView view)
            : base(userService, view)
        {
            this.View.UserUpdate += this.OnViewUpdateUser;
            this.View.UserMakeAdmin += this.OnViewMakeAdmin;
            this.View.UserRemoveAdmin += this.OnViewRemoveAdmin;
            this.View.UserDisable += this.OnViewDisableUser;
            this.View.UserEnable += this.OnViewEnableUser;
            this.View.UserSearch += this.OnViewUserSearch;
        }

        private void OnViewUserSearch(object sender, ISearchEventArgs e)
        {
            var currentPage = this.View.CurrentPage;
            var pageSize = this.View.PageSize;
            int total;
            var users = this.UserService.PaginatedUsers(currentPage, pageSize, out total, e?.Pattern);

            this.View.TotalPages = total;
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

        private void OnViewUpdateUser(object sender, IUserUpdateEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void OnViewMakeAdmin(object sender, IIdentifiableEventArgs<string> e)
        {
            var result = this.UserService.MakeAdmin(e.Id);
            if (result.Succeeded)
            {
                this.SetSuccess("User is now an administrator.");
            }
            else
            {
                this.SetError(string.Join(", ", result.Errors));
            }
        }

        private void OnViewRemoveAdmin(object sender, IIdentifiableEventArgs<string> e)
        {
            var result = this.UserService.RemoveAdmin(e.Id);
            if (result.Succeeded)
            {
                this.SetSuccess("Administrator removed.");
            }
            else
            {
                this.SetError(string.Join(", ", result.Errors));
            }
        }

        private void SetError(string error)
        {
            this.View.ErrorMessageVisible = true;
            this.View.ErrorMessageText = error;
        }

        private void SetSuccess(string message)
        {
            this.View.SuccessMessageVisible = true;
            this.View.SuccessMessageText = message;
        }
    }
}
