using System;
using System.Collections.Generic;

using RememBeer.Business.Reviews.My;
using RememBeer.Business.Reviews.My.Contracts;
using RememBeer.Models;
using RememBeer.WebClient.BasePages;

using WebFormsMvp;

namespace RememBeer.WebClient.Reviews
{
    [PresenterBinding(typeof(MyReviewsPresenter))]
    public partial class My : BaseMvpPage<ReviewsViewModel>, IMyReviewsView
    {
        public event EventHandler<EventArgs> OnInitialise;

        public event EventHandler<IBeerReviewInfoEventArgs> ReviewUpdate;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.OnInitialise?.Invoke(this, EventArgs.Empty);
        }

        public IEnumerable<BeerReview> Select()
        {
            return this.Model.Reviews;
        }

        public void UpdateReview(BeerReview newReview)
        {
            var args = this.EventArgsFactory.CreateBeerReviewInfoEventArgs(newReview);
            this.ReviewUpdate?.Invoke(this, args);
        }
    }
}
