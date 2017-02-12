using System;

using RememBeer.Business.Admin.Breweries.Contracts;
using RememBeer.Business.Common.EventArgs.Contracts;
using RememBeer.Data.Services.Contracts;

using WebFormsMvp;

namespace RememBeer.Business.Admin.Breweries
{
    public class BreweriesPresenter : Presenter<IBreweriesView>
    {
        private readonly IBreweryService breweryService;

        public BreweriesPresenter(IBreweryService breweryService, IBreweriesView view)
            : base(view)
        {
            if (breweryService == null)
            {
                throw new ArgumentNullException(nameof(breweryService));
            }

            this.breweryService = breweryService;
            this.View.Initialized += this.OnViewInitialized;
            this.View.BrewerySearch += this.OnViewSearch;
        }

        private void OnViewSearch(object sender, ISearchEventArgs e)
        {
            var breweries = this.breweryService.Search(e.Pattern);
            this.View.Model.Breweries = breweries;
        }

        private void OnViewInitialized(object sender, EventArgs e)
        {
            var breweries = this.breweryService.GetAll();
            this.View.Model.Breweries = breweries;
        }
    }
}
