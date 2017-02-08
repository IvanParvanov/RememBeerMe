using System;
using System.Data.Entity.Validation;

using Microsoft.AspNet.Identity;

using RememBeer.Business.Reviews.Common.Presenters;
using RememBeer.Business.Reviews.My.Contracts;
using RememBeer.Data.Services;
using RememBeer.Models;

namespace RememBeer.Business.Reviews.My
{
    public class MyReviewsPresenter : BeerReviewPresenter<IMyReviewsView>
    {
        public MyReviewsPresenter(IBeerReviewService reviewService, IMyReviewsView view)
            : base(reviewService, view)
        {
            this.View.OnInitialise += this.OnViewInitialise;
            this.View.ReviewUpdate += this.OnUpdateReview;
            this.View.CreateReview += this.OnCreateReview;
        }

        private void OnCreateReview(object sender, IBeerReviewInfoEventArgs e)
        {
            try
            {
                this.ReviewService.CreateReview(e.BeerReview);
                this.View.SuccessMessageText = "Review has been successfully created!";
                this.View.SuccessMessageVisible = true;
            }
            catch ( DbEntityValidationException ex )
            {
                foreach ( var eve in ex.EntityValidationErrors )
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach ( var ve in eve.ValidationErrors )
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception ex)
            {
                //TODO: Error handling
                throw;
            }
        }

        private void OnUpdateReview(object sender, IBeerReviewInfoEventArgs e)
        {
            var review = (BeerReview)e.BeerReview;
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
