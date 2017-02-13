using System;

using RememBeer.Business.Admin.Brewery.Contracts;
using RememBeer.Business.Admin.Common;
using RememBeer.Business.Common.EventArgs.Contracts;
using RememBeer.Data.Services.Contracts;

namespace RememBeer.Business.Admin.Brewery
{
    public class BreweryPresenter : BreweryServicePresenter<ISingleBreweryView>
    {
        private const string NotFoundMessage = "Brewery not found!";
        private const string UpdateSuccessMessage = "Brewery updated!";

        public BreweryPresenter(IBreweryService breweryService, ISingleBreweryView view)
            : base(breweryService, view)
        {
            this.View.BreweryUpdate += this.UpdateBrewery;
            this.View.Initialized += this.OnViewInitialized;
        }

        private void UpdateBrewery(object sender, IBreweryUpdateEventArgs e)
        {
            try
            {
                var brewery = this.BreweryService.UpdateBrewery(e.Id, e.Name, e.Country, e.Description);
                this.View.SuccessMessageText = UpdateSuccessMessage;
                this.View.SuccessMessageVisible = true;
                this.View.Model.Brewery = brewery;
            }
            catch (Exception exception)
            {
                this.View.ErrorMessageText = exception.Message;
                this.View.ErrorMessageVisible = true;
            }
        }

        private void OnViewInitialized(object sender, IIdentifiableEventArgs<string> e)
        {
            var id = e.Id;
            int intId;
            var isValidId = int.TryParse(id, out intId);

            if (isValidId)
            {
                var brewery = this.BreweryService.GetById(intId);
                if (brewery == null)
                {
                    this.ShowError(NotFoundMessage);
                }
                else
                {
                    this.View.Model.Brewery = brewery;
                }
            }
            else
            {
                this.ShowError(NotFoundMessage);
            }
        }

        private void ShowError(string message)
        {
            this.View.ErrorMessageText = message;
            this.View.ErrorMessageVisible = true;
        }
    }
}
