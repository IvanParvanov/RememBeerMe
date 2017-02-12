using System;

using RememBeer.Business.Common.Contracts;
using RememBeer.Business.Common.EventArgs.Contracts;

using WebFormsMvp;

namespace RememBeer.Business.Admin.Brewery
{
    public interface ISingleBreweryView : IView<SingleBreweryViewModel>, IViewWithErrors
    {
        event EventHandler<IIdentifiableEventArgs<string>> Initialized;
    }
}