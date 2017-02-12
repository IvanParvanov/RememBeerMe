using System;

using RememBeer.Data.Services.Contracts;

using WebFormsMvp;

namespace RememBeer.Business.Admin.Common
{
    public class BreweryServicePresenter<TView> : Presenter<TView> where TView : class, IView
    {
        private readonly IBreweryService breweryService;

        public BreweryServicePresenter(IBreweryService breweryService, TView view)
            : base(view)
        {
            if (breweryService == null)
            {
                throw new ArgumentNullException(nameof(breweryService));
            }

            this.breweryService = breweryService;
        }

        protected IBreweryService BreweryService => this.breweryService;
    }
}
