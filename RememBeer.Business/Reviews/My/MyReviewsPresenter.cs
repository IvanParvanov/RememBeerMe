using System;
using System.Linq;

using Microsoft.AspNet.Identity;

using RememBeer.Business.Reviews.Common.Presenters;
using RememBeer.Business.Reviews.My.Contracts;
using RememBeer.Data.Services.Contracts;

namespace RememBeer.Business.Reviews.My
{
    public class MyReviewsPresenter : BeerReviewPresenter<IMyReviewsView>
    {
        public MyReviewsPresenter(IBeerReviewService reviewService, IMyReviewsView view)
            : base(reviewService, view)
        {
            this.View.Initialized += this.OnViewInitialise;
            this.View.ReviewUpdate += this.OnUpdateReview;
            this.View.ReviewDelete += this.OnDeleteReview;
        }

        private void OnDeleteReview(object sender, IBeerReviewInfoEventArgs e)
        {
            var id = e.BeerReview.Id;
            try
            {
                this.ReviewService.DeleteReview(id);
                this.View.Model.Reviews = this.View.Model.Reviews.Where(r => !r.IsDeleted).ToList();

                this.View.SuccessMessageText = "Review deleted!";
                this.View.SuccessMessageVisible = true;
            }
            catch (Exception exception)
            {
                this.View.SuccessMessageText = exception.Message;
                this.View.SuccessMessageVisible = true;
            }
            
        }

        private void OnUpdateReview(object sender, IBeerReviewInfoEventArgs e)
        {
            var review = e.BeerReview;
            try
            {
                this.ReviewService.UpdateReview(review);
                this.View.SuccessMessageText = "Review successfully updated!";
                this.View.SuccessMessageVisible = true;
            }
            catch (Exception ex)
            {
                this.View.SuccessMessageText = ex.Message;
                this.View.SuccessMessageVisible = true;
            }
        }

        private void OnViewInitialise(object sender, EventArgs e)
        {
            this.View.SuccessMessageVisible = false;

            var userId = this.HttpContext?.User?.Identity.GetUserId();
            var beerReviews = this.ReviewService.GetReviewsForUser(userId);

            this.View.Model.Reviews = beerReviews;
        }
    }
}
