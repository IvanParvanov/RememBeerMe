using RememBeer.Business.Account.Common.Presenters;
using RememBeer.Business.Account.Register.Contracts;
using RememBeer.Data.Services;

namespace RememBeer.Business.Account.Register
{
    public class RegisterPresenter : UserServicePresenter<IRegisterView>
    {
        public RegisterPresenter(IUserService userService, IRegisterView view) 
            : base(userService, view)
        {
            this.View.OnRegister += this.OnRegister;
        }

        private void OnRegister(object sender, IRegisterEventArgs args)
        {
            //var ctx = this.AuthProvider.CreateOwinContext(this.HttpContext);

            //var manager = this.AuthProvider.CreateApplicationUserManager(ctx);
            //var signInManager = this.AuthProvider.CreateApplicationSignInManager(ctx);

            ////var user = new ApplicationUser() { UserName = this.Email.Text, Email = this.Email.Text };
            //var result = manager.Create(user, args.Password);
            //if (result.Succeeded)
            //{
            //    // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
            //    //string code = manager.GenerateEmailConfirmationToken(user.Id);
            //    //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
            //    //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

            //    signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
            //    this.IdentityHelper.RedirectToReturnUrl(this.Request.QueryString["ReturnUrl"], this.Response);
            //}
            //else
            //{
            //    this.View.ErrorMessageText = result.Errors.FirstOrDefault();
            //}
        }
    }
}
