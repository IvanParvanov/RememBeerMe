using System;

using RememBeer.Business.Logic.Common.Contracts;
using RememBeer.Business.Logic.Common.EventArgs.Contracts;

namespace RememBeer.Business.Logic.Admin.Breweries.Contracts
{
    public interface IBreweriesView : IInitializableView<BreweriesViewModel>
    {
        event EventHandler<ISearchEventArgs> BrewerySearch;
    }
}
