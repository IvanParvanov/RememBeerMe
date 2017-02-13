using System;

using RememBeer.Business.Common.Contracts;
using RememBeer.Business.Common.EventArgs.Contracts;

using WebFormsMvp;

namespace RememBeer.Business.Admin.Brewery.Contracts
{
    public interface ISingleBreweryView : IView<SingleBreweryViewModel>, IViewWithErrors, IViewWithSuccess
    {
        event EventHandler<IIdentifiableEventArgs<string>> Initialized;

        event EventHandler<IBreweryUpdateEventArgs> BreweryUpdate;
    }
}