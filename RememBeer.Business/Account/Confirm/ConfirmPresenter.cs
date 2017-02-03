using RememBeer.Business.Account.Auth;
using RememBeer.Business.Account.Common;
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

        private async void OnSubmit(object sender, IConfirmEventArgs args)
        {
            var code = args.Code;
            var userId = args.UserId;
            var ctx = args.Context;

            if (code != null && userId != null)
            {
                var manager = this.AuthFactory.CreateApplicationUserManager(ctx);
                var result = await manager.ConfirmEmailAsync(userId, code);
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
