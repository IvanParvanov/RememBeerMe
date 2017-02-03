﻿using System;
using System.Web;
using System.Web.UI;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using RememBeer.Data.Identity;
using RememBeer.Data.Identity.Contracts;

namespace RememBeer.WebClient.Account
{
    public partial class ManagePassword : Page
    {
        protected string SuccessMessage
        {
            get;
            private set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var manager = this.Context.GetOwinContext().GetUserManager<IApplicationUserManager>();

            if (!this.IsPostBack)
            {
                // Determine the sections to render
                if ( manager.HasPassword(this.User.Identity.GetUserId()) )
                {
                    this.changePasswordHolder.Visible = true;
                }
                else
                {
                    this.setPassword.Visible = true;
                    this.changePasswordHolder.Visible = false;
                }

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
                var manager = this.Context.GetOwinContext().GetUserManager<IApplicationUserManager>();
                var signInManager = this.Context.GetOwinContext().Get<IApplicationSignInManager>();
                IdentityResult result = manager.ChangePassword(this.User.Identity.GetUserId(), this.CurrentPassword.Text, this.NewPassword.Text);
                if (result.Succeeded)
                {
                    var user = manager.FindById(this.User.Identity.GetUserId());
                    signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                    this.Response.Redirect("~/Account/Manage?m=ChangePwdSuccess");
                }
                else
                {
                    this.AddErrors(result);
                }
            }
        }

        protected void SetPassword_Click(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                // Create the local login info and link the local account to the user
                var manager = this.Context.GetOwinContext().GetUserManager<IApplicationUserManager>();
                IdentityResult result = manager.AddPassword(this.User.Identity.GetUserId(), this.password.Text);
                if (result.Succeeded)
                {
                    this.Response.Redirect("~/Account/Manage?m=SetPwdSuccess");
                }
                else
                {
                    this.AddErrors(result);
                }
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                this.ModelState.AddModelError("", error);
            }
        }
    }
}