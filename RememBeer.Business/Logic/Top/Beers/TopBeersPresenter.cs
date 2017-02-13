using System;

using RememBeer.Business.Logic.Common.Contracts;
using RememBeer.Business.Services.Contracts;
using RememBeer.Common.Constants;

using WebFormsMvp;

namespace RememBeer.Business.Logic.Top.Beers
{
    public class TopBeersPresenter : Presenter<IInitializableView<TopBeersViewModel>>
    {
        private readonly ITopBeersService topBeersService;

        public TopBeersPresenter(ITopBeersService topBeersService, IInitializableView<TopBeersViewModel> view)
            : base(view)
        {
            if (topBeersService == null)
            {
                throw new ArgumentNullException(nameof(topBeersService));
            }

            this.topBeersService = topBeersService;
            this.View.Initialized += this.OnViewInitialize;
        }

        private void OnViewInitialize(object sender, EventArgs e)
        {
            var beers = this.topBeersService.GetTopBeers(Constants.TopBeersCount);
            this.View.Model.Rankings = beers;
        }
    }
}
