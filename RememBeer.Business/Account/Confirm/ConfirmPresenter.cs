using RememBeer.Business.Account.Auth;
using RememBeer.Business.Account.Confirm.Contracts;

using WebFormsMvp;

namespace RememBeer.Business.Account.Confirm
{
    public class ConfirmPresenter : Presenter<IConfirmView>
    {
        private readonly IAuthFactory authFactory;

        public ConfirmPresenter(IAuthFactory authFactory, IConfirmView view)
            : base(view)
        {
            this.authFactory = authFactory;
            this.View.OnSubmit += this.OnSubmit;
        }

        private async void OnSubmit(object sender, IConfirmEventArgs args)
        {
            var code = args.Code;
            var userId = args.UserId;
            var ctx = args.Context;

            if (code != null && userId != null)
            {
                var manager = this.authFactory.CreateApplicationUserManager(ctx);
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
