using System;
using System.Linq;
using System.Web;

using Microsoft.AspNet.Identity.Owin;

using RememBeer.Business.Account.Common.ViewModels;
using RememBeer.Business.Account.Register;
using RememBeer.Business.Account.Register.Contracts;
using RememBeer.Common.Identity.Contracts;
using RememBeer.Common.Identity.Models;
using RememBeer.WebClient.BasePages;

using WebFormsMvp;

namespace RememBeer.WebClient.Account
{
    [PresenterBinding(typeof(RegisterPresenter))]
    public partial class Register : BaseMvpPage<StatelessViewModel>, IRegisterView
    {
        public event EventHandler<IRegisterEventArgs> OnRegister;

        public string ErrorMessageText
        {
            get { return this.ErrorMessage.Text; }
            set { this.ErrorMessage.Text = value; }
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var args = this.EventArgsFactory.CreateRegisterEventArg(this.Email.Text, this.Email.Text, this.Password.Text);
            //this.OnRegister?.Invoke(this, args);


            var manager = this.Context.GetOwinContext().GetUserManager<IApplicationUserManager>();
            var signInManager = this.Context.GetOwinContext().Get<IApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = this.Email.Text, Email = this.Email.Text };
            var result = manager.Create(user, this.Password.Text);
            if ( result.Succeeded )
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                this.IdentityHelper.RedirectToReturnUrl(this.Request.QueryString["ReturnUrl"], this.Response);
            }
            else
            {
                this.ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}