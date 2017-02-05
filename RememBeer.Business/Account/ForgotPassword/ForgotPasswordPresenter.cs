using RememBeer.Business.Account.ForgotPassword.Contracts;

using RememBeer.Business.Account.Auth;
using RememBeer.Business.Account.Common.Presenters;

namespace RememBeer.Business.Account.ForgotPassword
{
    public class ForgotPasswordPresenter : AuthenticationPresenter<IForgotPasswordView>
    {
        public ForgotPasswordPresenter(IAuthFactory authFactory, IForgotPasswordView view)
            : base(authFactory, view)
        {
            this.View.OnForgot += this.OnForgot;
        }

        private void OnForgot(object sender, IForgotPasswordEventArgs args)
        {
            var owinContext = this.AuthFactory.GetOwinContext(this.HttpContext);

            var manager = this.AuthFactory.CreateApplicationUserManager(owinContext);
            var user = manager.FindByName(args.Email);
            if (user == null || !manager.IsEmailConfirmed(user.Id))
            {
                this.View.FailureMessage = "The user does not exist or the email is not confirmed.";
                this.View.ErrorMessageVisible = true;
                return;
            }
            // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
            // Send email with the code and the redirect to reset password page
            //string code = manager.GeneratePasswordResetToken(user.Id);
            //string callbackUrl = IdentityHelper.GetResetPasswordRedirectUrl(code, Request);
            //manager.SendEmail(user.Id, "Reset Password", "Please reset your password by clicking <a href=\"" + callbackUrl + "\">here</a>.");
            this.View.LoginFormVisible = false;
            this.View.DisplayEmailVisible = true;
        }
    }
}
