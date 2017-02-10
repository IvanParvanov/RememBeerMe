using System;

using RememBeer.Business.Common.Contracts;
using RememBeer.Business.Top.Beers;
using RememBeer.WebClient.BasePages;

using WebFormsMvp;

namespace RememBeer.WebClient.Top
{
    [PresenterBinding(typeof(TopBeersPresenter))]
    public partial class Beers : BaseMvpPage<TopBeersViewModel>, IInitializableView<TopBeersViewModel>
    {
        public event EventHandler<EventArgs> OnInitialize;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.OnInitialize?.Invoke(this, EventArgs.Empty);

            this.RankingGridView.DataSource = this.Model.Rankings;
            this.RankingGridView.DataBind();
        }
    }
}