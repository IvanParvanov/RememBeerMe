using RememBeer.Business.Common.EventArgs.Contracts;
using RememBeer.Business.Reviews.Common.Presenters;
using RememBeer.Business.Reviews.Default.Contracts;
using RememBeer.Data.Services;

namespace RememBeer.Business.Reviews.Default
{
    public class DefaultPresenter : BeerReviewPresenter<IReviewDetailsView>
    {
        public DefaultPresenter(IBeerReviewService reviewService, IReviewDetailsView view)
            : base(reviewService, view)
        {
            this.View.OnInitialise += this.OnViewInitialise;
        }

        private void OnViewInitialise(object sender, IIdentifiableEventArgs<int> e)
        {
            var id = e.Id;
            var review = this.ReviewService.GetById(id);
            if (review != null)
            {
                this.View.Model.Review = review;
                this.View.NotFoundVisible = false;
            }
            else
            {
                this.View.NotFoundVisible = true;
            }
        }
    }
}
