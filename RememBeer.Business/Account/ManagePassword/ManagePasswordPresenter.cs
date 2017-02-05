﻿using RememBeer.Business.Account.Auth;
using RememBeer.Business.Account.Common.Presenters;
using RememBeer.Business.Account.ManagePassword.Contracts;

namespace RememBeer.Business.Account.ManagePassword
{
    public class ManagePasswordPresenter : AuthenticationPresenter<IManagePasswordView>
    {
        public ManagePasswordPresenter(IAuthFactory authFactory, IManagePasswordView view)
            : base(authFactory, view)
        {
            this.View.ChangePassword += this.OnChangePassword;
        }

        private void OnChangePassword(object sender, IChangePasswordEventArgs args)
        {
            var userId = args.UserId;
            var ctx = this.AuthFactory.GetOwinContext(this.HttpContext);
            var manager = this.AuthFactory.CreateApplicationUserManager(ctx);

            var result = manager.ChangePassword(userId, args.CurrentPassword, args.NewPassword);
            if (result.Succeeded)
            {
                var signInManager = this.AuthFactory.CreateApplicationSignInManager(ctx);
                var user = manager.FindById(userId);
                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                this.Response.Redirect("~/Account/Manage?m=ChangePwdSuccess");
            }
            else
            {
                this.View.AddErrors(result.Errors);
            }
        }
    }
}