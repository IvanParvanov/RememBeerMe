using System;
using System.Web;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using RememBeer.Data.Identity;
using RememBeer.Data.Identity.Contracts;

namespace RememBeer.WebClient.Account
{
    public partial class Manage : System.Web.UI.Page
    {
        protected string SuccessMessage { get; private set; }

        protected void Page_Load()
        {
            var manager = this.Context.GetOwinContext().GetUserManager<IApplicationUserManager>();

            var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            if (!this.IsPostBack)
            {
                // Determine the sections to render
                var userId = this.User.Identity.GetUserId();
                if (manager.HasPassword(userId))
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
                        message == "ChangePwdSuccess"
                            ? "Your password has been changed."
                            : message == "SetPwdSuccess"
                                ? "Your password has been set."
                                : message == "RemoveLoginSuccess"
                                    ? "The account was removed."
                                    : message == "AddPhoneNumberSuccess"
                                        ? "Phone number has been added"
                                        : message == "RemovePhoneNumberSuccess"
                                            ? "Phone number was removed"
                                            : string.Empty;
                    this.successMessage.Visible = !string.IsNullOrEmpty(this.SuccessMessage);
                }
            }
        }
    }
}
