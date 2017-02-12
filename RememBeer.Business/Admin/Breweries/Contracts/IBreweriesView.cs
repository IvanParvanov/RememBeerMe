using System;

using RememBeer.Business.Common.EventArgs.Contracts;

using WebFormsMvp;

namespace RememBeer.Business.Admin.Breweries.Contracts
{
    public interface IBreweriesView : IView<BreweriesViewModel>
    {
        event EventHandler<EventArgs> Initialized;

        event EventHandler<ISearchEventArgs> BrewerySearch;
    }
}
