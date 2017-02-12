using System;

using RememBeer.Business.Common.Contracts;
using RememBeer.Business.Common.EventArgs.Contracts;

namespace RememBeer.Business.Admin.Breweries.Contracts
{
    public interface IBreweriesView : IInitializableView<BreweriesViewModel>
    {
        event EventHandler<ISearchEventArgs> BrewerySearch;
    }
}
