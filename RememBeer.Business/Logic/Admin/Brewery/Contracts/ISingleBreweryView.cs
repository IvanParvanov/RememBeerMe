using System;

using RememBeer.Business.Logic.Common.Contracts;
using RememBeer.Business.Logic.Common.EventArgs.Contracts;

using WebFormsMvp;

namespace RememBeer.Business.Logic.Admin.Brewery.Contracts
{
    public interface ISingleBreweryView : IView<SingleBreweryViewModel>, IViewWithErrors, IViewWithSuccess
    {
        event EventHandler<IIdentifiableEventArgs<string>> Initialized;

        event EventHandler<IBreweryUpdateEventArgs> BreweryUpdate;
    }
}
