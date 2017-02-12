﻿using System;

using RememBeer.Business.Admin.Breweries.Contracts;
using RememBeer.Business.Admin.Common;
using RememBeer.Business.Common.EventArgs.Contracts;
using RememBeer.Data.Services.Contracts;

namespace RememBeer.Business.Admin.Breweries
{
    public class BreweriesPresenter : BreweryServicePresenter<IBreweriesView>
    {
        public BreweriesPresenter(IBreweryService breweryService, IBreweriesView view)
            : base(breweryService, view)
        {
            this.View.Initialized += this.OnViewInitialized;
            this.View.BrewerySearch += this.OnViewSearch;
        }

        private void OnViewSearch(object sender, ISearchEventArgs e)
        {
            var breweries = this.BreweryService.Search(e.Pattern);
            this.View.Model.Breweries = breweries;
        }

        private void OnViewInitialized(object sender, EventArgs e)
        {
            var breweries = this.BreweryService.GetAll();
            this.View.Model.Breweries = breweries;
        }
    }
}
