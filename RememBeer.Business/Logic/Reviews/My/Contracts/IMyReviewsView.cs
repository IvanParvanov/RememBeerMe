using System;

using RememBeer.Business.Logic.Common.Contracts;

namespace RememBeer.Business.Logic.Reviews.My.Contracts
{
    public interface IMyReviewsView : IInitializableView<ReviewsViewModel>
    {
        /// <summary>
        /// Triggered when a review needs to be updated.
        /// </summary>
        event EventHandler<IBeerReviewInfoEventArgs> ReviewUpdate;

        /// <summary>
        /// Triggered when a review needs to be deleted.
        /// </summary>
        event EventHandler<IBeerReviewInfoEventArgs> ReviewDelete;

        string SuccessMessageText { get; set; }

        bool SuccessMessageVisible { get; set; }
    }
}
