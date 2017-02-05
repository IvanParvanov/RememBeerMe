﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;

using Microsoft.AspNet.Identity;

using RememBeer.Business.Account.Common.ViewModels;
using RememBeer.Business.Account.ManagePassword;
using RememBeer.Business.Account.ManagePassword.Contracts;
using RememBeer.WebClient.BasePages;

using WebFormsMvp;

namespace RememBeer.WebClient.Account
{
    [PresenterBinding(typeof(ManagePasswordPresenter))]
    public partial class ManagePassword : BaseMvpPage<StatelessViewModel>, IManagePasswordView
    {
        public string SuccessMessage { get; set; }

        public event EventHandler<IChangePasswordEventArgs> ChangePassword;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                // Render success message
                var message = this.Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    this.Form.Action = this.ResolveUrl("~/Account/Manage");
                }
            }
        }

        protected void ChangePassword_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                var ctx = this.Context.GetOwinContext();
                var userId = this.User.Identity.GetUserId();
                var args = this.EventArgsFactory.CreateChangePasswordEventArgs(ctx, this.CurrentPassword.Text, this.NewPassword.Text, userId);
                this.ChangePassword?.Invoke(this, args);
            }
        }

        public void AddErrors(IEnumerable<string> errors)
        {
            foreach (var error in errors)
            {
                this.ModelState.AddModelError("", error);
            }
        }
    }
}
