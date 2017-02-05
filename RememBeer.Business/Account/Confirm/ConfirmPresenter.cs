using RememBeer.Business.Account.Auth;
using RememBeer.Business.Account.Common.Presenters;
using RememBeer.Business.Account.Confirm.Contracts;

namespace RememBeer.Business.Account.Confirm
{
    public class ConfirmPresenter : AuthenticationPresenter<IConfirmView>
    {
        public ConfirmPresenter(IAuthFactory authFactory, IConfirmView view)
            : base(authFactory, view)
        {
            this.View.OnSubmit += this.OnSubmit;
        }

        private void OnSubmit(object sender, IConfirmEventArgs args)
        {
            var code = args.Code;
            var userId = args.UserId;
            var ctx = this.AuthFactory.GetOwinContext(this.HttpContext);

            if (code != null && userId != null)
            {
                var manager = this.AuthFactory.CreateApplicationUserManager(ctx);
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
