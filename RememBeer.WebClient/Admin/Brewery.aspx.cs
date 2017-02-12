using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

using RememBeer.Business.Admin.Brewery;
using RememBeer.Business.Common.EventArgs.Contracts;
using RememBeer.Models.Contracts;
using RememBeer.WebClient.BasePages;

using WebFormsMvp;

namespace RememBeer.WebClient.Admin
{
    [PresenterBinding(typeof(BreweryPresenter))]
    public partial class Brewery : BaseMvpPage<SingleBreweryViewModel>, ISingleBreweryView
    {
        public event EventHandler<IIdentifiableEventArgs<string>> Initialized;

        public string ErrorMessageText
        {
            get
            {
                return this.Notifier.ErrorText;
            }

            set
            {
                this.Notifier.ErrorText = value;
            }
        }

        public bool ErrorMessageVisible
        {
            get
            {
                return this.Notifier.ErrorVisible;
            }

            set
            {
                this.Notifier.ErrorVisible = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var id = this.Request.QueryString["id"];
            var args = this.EventArgsFactory.CreateIdentifiableEventArgs(id);
            this.Initialized?.Invoke(this, args);
            if (this.Model.Brewery != null)
            {
                this.BindData();
            }
        }

        private void BindData()
        {
            this.BreweryDetails.DataSource = new List<IBrewery>()
                                             {
                                                 this.Model.Brewery
                                             };
            this.BreweryDetails.DataBind();
        }

        protected void BreweryDetails_OnModeChanging(object sender, DetailsViewModeEventArgs e)
        {
        }
    }
}
