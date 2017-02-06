using System;

using Microsoft.AspNet.Identity;

using RememBeer.Business.Reviews.My.Contracts;
using RememBeer.Data.Services;

using WebFormsMvp;

namespace RememBeer.Business.Reviews.My
{
    public class MyReviewsPresenter : Presenter<IMyReviewsView>
    {
        private readonly IBeerReviewService beerService;

        public MyReviewsPresenter(IBeerReviewService beerService, IMyReviewsView view)
            : base(view)
        {
            if (beerService == null)
            {
                throw new ArgumentNullException(nameof(beerService));
            }

            this.beerService = beerService;
            this.View.OnInitialise += this.OnViewInitialise;
        }

        private void OnViewInitialise(object sender, EventArgs e)
        {
            var userId = this.HttpContext?.User?.Identity.GetUserId();
            if (userId == null)
            {

            }
            else
            {
                var beerReviews = this.beerService.GetReviewsForUser(userId);

                this.View.Model.Reviews = beerReviews;
            }
            
        }
    }
}
