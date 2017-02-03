using System;
using System.Web;

using RememBeer.Business.Account.ForgotPassword;
using RememBeer.Business.Account.ForgotPassword.Contracts;

using WebFormsMvp;
using WebFormsMvp.Web;

namespace RememBeer.WebClient.Account
{
    [PresenterBinding(typeof(ForgotPasswordPresenter))]
    public partial class ForgotPassword : MvpPage<ForgotPasswordViewModel>, IForgotPasswordView
    {
        public event EventHandler<IForgottenPasswordEventArgs> OnForgot;

        public string FailureMessage
        {
            get { return this.FailureText.Text; }
            set { this.FailureText.Text = value; }
        }

        public bool ErrorMessageVisible
        {
            get { return this.ErrorMessage.Visible; }
            set { this.ErrorMessage.Visible = value; }
        }

        public bool LoginFormVisible
        {
            get { return this.loginForm.Visible; }
            set { this.loginForm.Visible = value; }
        }

        public bool DisplayEmailVisible
        {
            get { return this.DisplayEmail.Visible; }
            set { this.DisplayEmail.Visible = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Forgot(object sender, EventArgs e)
        {
            if (this.IsValid)
            {
                var context = this.Context.GetOwinContext();
                this.OnForgot?.Invoke(this, new ForgottenPasswordEventArgs(context, this.Email.Text));
            }
        }
    }
}