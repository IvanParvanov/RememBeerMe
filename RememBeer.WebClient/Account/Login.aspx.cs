﻿using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

using Ninject;

using Owin;

using RememBeer.Data;

namespace RememBeer.WebClient.Account
{
    public partial class Login : Page
    {
        [Inject]
        public IIdentityHelper IdentityHelper { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.RegisterHyperLink.NavigateUrl = "Register";
            // Enable this once you have account confirmation enabled for password reset functionality
            //ForgotPasswordHyperLink.NavigateUrl = "Forgot";
            this.OpenAuthLogin.ReturnUrl = this.Request.QueryString["ReturnUrl"];
            var returnUrl = HttpUtility.UrlEncode(this.Request.QueryString["ReturnUrl"]);
            if (!string.IsNullOrEmpty(returnUrl))
            {
                this.RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
            }
        }

        protected void LogIn(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                // Validate the user password
                var manager = this.Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
                var signinManager = this.Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

                var result = signinManager.PasswordSignIn(this.Email.Text, this.Password.Text, this.RememberMe.Checked, shouldLockout: true);

                switch (result)
                {
                    case SignInStatus.Success:
                        IdentityHelper.RedirectToReturnUrl(this.Request.QueryString["ReturnUrl"], this.Response);
                        break;
                    case SignInStatus.LockedOut:
                        this.Response.Redirect("/Account/Lockout");
                        break;
                    case SignInStatus.RequiresVerification:
                        this.Response.Redirect(string.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", this.Request.QueryString["ReturnUrl"], this.RememberMe.Checked),
                                          true);
                        break;
                    case SignInStatus.Failure:
                    default:
                        this.FailureText.Text = "Invalid login attempt";
                        this.ErrorMessage.Visible = true;
                        break;
                }
            }
        }
    }
}