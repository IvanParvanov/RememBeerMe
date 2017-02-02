using RememBeer.Business.Account.ForgotPassword.Contracts;
using RememBeer.Data;

using Microsoft.AspNet.Identity.Owin;

using RememBeer.Business.Account.Auth;

using WebFormsMvp;

namespace RememBeer.Business.Account.ForgotPassword
{
    public class ForgotPasswordPresenter : Presenter<IForgotPasswordView>
    {
        private readonly IAuthFactory authFactory;

        public ForgotPasswordPresenter(IAuthFactory authFactory, IForgotPasswordView view)
            : base(view)
        {
            this.authFactory = authFactory;
            this.View.OnForgot += this.OnForgot;
        }

        private async void OnForgot(object sender, IForgottenPasswordEventArgs args)
        {
            var manager = this.authFactory.CreateApplicationUserManager(args.Context);
            var user = await manager.FindByNameAsync(args.Email);
            if (user == null || !await manager.IsEmailConfirmedAsync(user.Id))
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
