using System;
using System.Collections.Generic;
using System.Linq;

using RememBeer.Business.Logic.Common.EventArgs.Contracts;
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
        public event EventHandler<IPaginationEventArgs> Initialized;

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

        public IEnumerable<IBeerReview> Select(int startRowIndex, int maximumRows, out int totalRowCount)
        {
            var args = this.EventArgsFactory.CreatePaginationEventArgs(startRowIndex, maximumRows);
            this.Initialized?.Invoke(this, args);

            totalRowCount = this.Model.TotalCount;
            return this.Model.Reviews;
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
