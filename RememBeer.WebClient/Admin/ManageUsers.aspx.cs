using System;
using System.Web.UI.WebControls;

using RememBeer.Business.Logic.Admin.ManageUsers;
using RememBeer.Business.Logic.Admin.ManageUsers.Contracts;
using RememBeer.Business.Logic.Common.EventArgs.Contracts;
using RememBeer.WebClient.BasePages;

using WebFormsMvp;

namespace RememBeer.WebClient.Admin
{
    [PresenterBinding(typeof(ManageUsersPresenter))]
    public partial class ManageUsers : BaseMvpPage<ManageUsersViewModel>, IManageUsersView
    {
        public event EventHandler<EventArgs> Initialized;

        public event EventHandler<IIdentifiableEventArgs<string>> UserDisable;

        public event EventHandler<IIdentifiableEventArgs<string>> UserEnable;

        public event EventHandler<IIdentifiableEventArgs<string>> UserMakeAdmin;

        public event EventHandler UserUpdate;

        public event EventHandler UserSearch;

        public int CurrentPage => this.UserGridView.PageIndex;

        public int PageSize => this.UserGridView.PageSize;

        public int TotalPages { get; set; }

        public string ErrorMessageText
        {
            get
            {
                return this.Notification.ErrorText;
            }
            set
            {
                this.Notification.ErrorText = value;
            }
        }

        public bool ErrorMessageVisible
        {
            get
            {
                return this.Notification.ErrorVisible;
            }
            set
            {
                this.Notification.ErrorVisible = value;
            }
        }

        public string SuccessMessageText
        {
            get
            {
                return this.Notification.SuccessText;
            }
            set
            {
                this.Notification.SuccessText = value;
            }
        }

        public bool SuccessMessageVisible
        {
            get
            {
                return this.Notification.SuccessVisible;
            }
            set
            {
                this.Notification.SuccessVisible = value;
            }
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.Initialized?.Invoke(this, EventArgs.Empty);
            this.BindData();
        }

        private void BindData()
        {
            this.UserGridView.VirtualItemCount = this.TotalPages;
            this.UserGridView.DataSource = this.Model.Users;
            this.UserGridView.DataBind();
        }

        protected void UserGridView_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            if (e.NewPageIndex >= 0)
            {
                this.UserGridView.PageIndex = e.NewPageIndex;
                this.BindData();
            }
        }

        protected void UserGridView_OnRowEditing(object sender, GridViewEditEventArgs e)
        {
            this.UserGridView.EditIndex = e.NewEditIndex;
            this.BindData();
        }

        protected void UserGridView_OnRowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            this.UserGridView.EditIndex = -1;
            this.BindData();
        }

        protected void UserGridView_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected void OnDisableEnableCommand(object sender, CommandEventArgs e)
        {
            var userId = (string)e.CommandArgument;
            var args = this.EventArgsFactory.CreateIdentifiableEventArgs(userId);
            switch (e.CommandName)
            {
                case "EnableUser":
                    this.UserEnable?.Invoke(this, args);
                    break;
                case "DisableUser":
                    this.UserDisable?.Invoke(this, args);
                    break;
            }
        }
    }
}