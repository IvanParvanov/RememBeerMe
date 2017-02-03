using System;
using System.Web;

using Ninject;

using RememBeer.Data;
using RememBeer.Business.Account.Confirm;
using RememBeer.Business.Account.Confirm.Contracts;
using RememBeer.WebClient.BasePages;

using WebFormsMvp;
using WebFormsMvp.Web;

namespace RememBeer.WebClient.Account
{
    [PresenterBinding(typeof(ConfirmPresenter))]
    public partial class Confirm : IdentityHelperPage<ConfirmViewModel>, IConfirmView
    {
        public event EventHandler<IConfirmEventArgs> OnSubmit;

        public bool SuccessPanelVisible { get; set; }

        public bool ErrorPanelVisible { get; set; }

        public string StatusMessage { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var code = this.IdentityHelper.GetCodeFromRequest(this.Request);
            var userId = this.IdentityHelper.GetUserIdFromRequest(this.Request);
            var ctx = this.Context.GetOwinContext();
            var args = new ConfirmEventArgs(userId, code, ctx);

            this.OnSubmit?.Invoke(this, args);
        }
    }
}