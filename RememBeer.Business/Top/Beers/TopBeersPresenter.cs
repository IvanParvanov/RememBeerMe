using System;

using RememBeer.Business.Common.Contracts;
using RememBeer.Data.Services.Contracts;

using WebFormsMvp;

namespace RememBeer.Business.Top.Beers
{
    public class TopBeersPresenter : Presenter<IInitializableView<TopBeersViewModel>>
    {
        private const int TopBeersCount = 10;

        private readonly ITopBeersService topBeersService;

        public TopBeersPresenter(ITopBeersService topBeersService, IInitializableView<TopBeersViewModel> view)
            : base(view)
        {
            if (topBeersService == null)
            {
                throw new ArgumentNullException(nameof(topBeersService));
            }

            this.topBeersService = topBeersService;
            this.View.OnInitialize += this.OnViewInitialize;
        }

        private void OnViewInitialize(object sender, EventArgs e)
        {
            var beers = this.topBeersService.GetTopBeers(TopBeersCount);
            this.View.Model.Rankings = beers;
        }
    }
}
