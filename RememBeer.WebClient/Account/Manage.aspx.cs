using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;

using RememBeer.Data;
using RememBeer.Data.Identity;

namespace RememBeer.WebClient.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected string SuccessMessage
        {
            get;
            private set;
        }

        private bool HasPassword(ApplicationUserManager manager)
        {
            return manager.HasPassword(this.User.Identity.GetUserId());
        }

        public bool HasPhoneNumber { get; private set; }

        public bool TwoFactorEnabled { get; private set; }

        public bool TwoFactorBrowserRemembered { get; private set; }

        public int LoginsCount { get; set; }

        protected void Page_Load()
        {
            var manager = this.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();

            this.HasPhoneNumber = string.IsNullOrEmpty(manager.GetPhoneNumber(this.User.Identity.GetUserId()));

            this.TwoFactorEnabled = manager.GetTwoFactorEnabled(this.User.Identity.GetUserId());

            this.LoginsCount = manager.GetLogins(this.User.Identity.GetUserId()).Count;

            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            if (!this.IsPostBack)
            {
                // Determine the sections to render
                if (this.HasPassword(manager))
                {
                    this.ChangePassword.Visible = true;
                }
                else
                {
                    this.CreatePassword.Visible = true;
                    this.ChangePassword.Visible = false;
                }

                // Render success message
                var message = this.Request.QueryString["m"];
                if (message != null)
                {
                    // Strip the query string from action
                    this.Form.Action = this.ResolveUrl("~/Account/Manage");

                    this.SuccessMessage =
                        message == "ChangePwdSuccess" ? "Your password has been changed."
                        : message == "SetPwdSuccess" ? "Your password has been set."
                        : message == "RemoveLoginSuccess" ? "The account was removed."
                        : message == "AddPhoneNumberSuccess" ? "Phone number has been added"
                        : message == "RemovePhoneNumberSuccess" ? "Phone number was removed"
                        : string.Empty;
                    this.successMessage.Visible = !string.IsNullOrEmpty(this.SuccessMessage);
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

        // Remove phonenumber from user
        protected void RemovePhone_Click(object sender, EventArgs e)
        {
            var manager = this.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = this.Context.GetOwinContext().Get<ApplicationSignInManager>();
            var result = manager.SetPhoneNumber(this.User.Identity.GetUserId(), null);
            if (!result.Succeeded)
            {
                return;
            }
            var user = manager.FindById(this.User.Identity.GetUserId());
            if (user != null)
            {
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                this.Response.Redirect("/Account/Manage?m=RemovePhoneNumberSuccess");
            }
        }
    }
}