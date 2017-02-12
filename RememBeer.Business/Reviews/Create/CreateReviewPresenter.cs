using System;

using RememBeer.Business.Reviews.Common.Presenters;
using RememBeer.Business.Reviews.Create.Contracts;
using RememBeer.Business.Reviews.My.Contracts;
using RememBeer.Common.Services;
using RememBeer.Common.Services.Contracts;
using RememBeer.Data.Services;
using RememBeer.Data.Services.Contracts;

namespace RememBeer.Business.Reviews.Create
{
    public class CreateReviewPresenter : BeerReviewPresenter<ICreateReviewView>
    {
        private readonly IImageUploadService imgUploadService;

        public CreateReviewPresenter(IBeerReviewService reviewService, IImageUploadService imgUploadService, ICreateReviewView view)
            : base(reviewService, view)
        {
            if (imgUploadService == null)
            {
                throw new ArgumentNullException(nameof(imgUploadService));
            }

            this.imgUploadService = imgUploadService;
            this.View.OnCreateReview += this.OnViewCreateReview;
        }

        private void OnViewCreateReview(object sender, IBeerReviewInfoEventArgs e)
        {
            var review = e.BeerReview;
            var image = e.Image;
            if (image != null)
            {
                var url = this.imgUploadService.UploadImage(image, 300, 300);
                review.ImgUrl = url ?? review.ImgUrl;
            }

            this.ReviewService.CreateReview(review);
            //this.View.SuccessMessageText = "Review has been successfully created!";
            //this.View.SuccessMessageVisible = true;

            this.Response.Redirect("/Reviews/My");
        }
    }
}
