using System;
using System.Collections.Generic;
using System.Linq;

using RememBeer.Business.Logic.Reviews.My;
using RememBeer.Business.Logic.Reviews.My.Contracts;
using RememBeer.Models;
using RememBeer.Models.Contracts;
using RememBeer.WebClient.BasePages;

using WebFormsMvp;

namespace RememBeer.WebClient.Reviews
{
    [PresenterBinding(typeof(MyReviewsPresenter))]
    public partial class My : BaseMvpPage<ReviewsViewModel>, IMyReviewsView
    {
        public event EventHandler<EventArgs> Initialized;

        public event EventHandler<IBeerReviewInfoEventArgs> ReviewUpdate;

        public event EventHandler<IBeerReviewInfoEventArgs> ReviewDelete;

        public string SuccessMessageText
        {
            get
            {
                return this.Notifier.SuccessText;
            }
            set
            {
                this.Notifier.SuccessText = value;
            }
        }

        public bool SuccessMessageVisible
        {
            get
            {
                return this.Notifier.SuccessVisible;
            }
            set
            {
                this.Notifier.SuccessVisible = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Initialized?.Invoke(this, EventArgs.Empty);
        }

        public IEnumerable<IBeerReview> Select(int startRowIndex, int maximumRows, out int totalRowCount)
        {
            totalRowCount = this.Model.Reviews.Count();

            return this.Model.Reviews.Skip(startRowIndex).Take(maximumRows);
        }

        public void UpdateReview(BeerReview newReview)
        {
            var args = this.EventArgsFactory.CreateBeerReviewInfoEventArgs(newReview);
            this.ReviewUpdate?.Invoke(this, args);
        }

        public void DeleteReview(BeerReview review)
        {
            var args = this.EventArgsFactory.CreateBeerReviewInfoEventArgs(review);
            this.ReviewDelete?.Invoke(this, args);
        }
    }
}
