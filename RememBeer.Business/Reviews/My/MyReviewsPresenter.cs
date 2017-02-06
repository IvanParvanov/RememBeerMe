using System;

using Microsoft.AspNet.Identity;

using RememBeer.Business.Reviews.My.Contracts;
using RememBeer.Data.Services;

using WebFormsMvp;

namespace RememBeer.Business.Reviews.My
{
    public class MyReviewsPresenter : Presenter<IMyReviewsView>
    {
        private readonly IBeerReviewService reviewService;

        public MyReviewsPresenter(IBeerReviewService reviewService, IMyReviewsView view)
            : base(view)
        {
            if (reviewService == null)
            {
                throw new ArgumentNullException(nameof(reviewService));
            }

            this.reviewService = reviewService;
            this.View.OnInitialise += this.OnViewInitialise;
            this.View.ReviewUpdate += this.OnReviewUpdate;
        }

        private void OnReviewUpdate(object sender, IBeerReviewInfoEventArgs e)
        {
            var review = e.BeerReview;
            this.reviewService.UpdateReview(review);
        }

        private void OnViewInitialise(object sender, EventArgs e)
        {
            var userId = this.HttpContext?.User?.Identity.GetUserId();
            var beerReviews = this.reviewService.GetReviewsForUser(userId);

            this.View.Model.Reviews = beerReviews;
        }
    }
}
