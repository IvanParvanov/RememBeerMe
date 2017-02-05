using RememBeer.Business.Account.Auth;
using RememBeer.Business.Account.Common.Presenters;
using RememBeer.Business.Account.Confirm.Contracts;

namespace RememBeer.Business.Account.Confirm
{
    public class ConfirmPresenter : AuthenticationPresenter<IConfirmView>
    {
        public ConfirmPresenter(IAuthProvider authProvider, IConfirmView view)
            : base(authProvider, view)
        {
            this.View.OnSubmit += this.OnSubmit;
        }

        private void OnSubmit(object sender, IConfirmEventArgs args)
        {
            var code = args.Code;
            var userId = args.UserId;
            var ctx = this.AuthProvider.CreateOwinContext(this.HttpContext);

            if (code != null && userId != null)
            {
                var manager = this.AuthProvider.CreateApplicationUserManager(ctx);
                var result = manager.ConfirmEmail(userId, code);
                if (result.Succeeded)
                {
                    this.View.SuccessPanelVisible = true;
                    return;
                }
            }

            this.View.SuccessPanelVisible = false;
            this.View.ErrorPanelVisible = true;
        }
    }
}
