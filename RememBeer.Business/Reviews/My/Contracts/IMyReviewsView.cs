using System;

using RememBeer.Business.Common.Contracts;

namespace RememBeer.Business.Reviews.My.Contracts
{
    public interface IMyReviewsView : IInitializableView<ReviewsViewModel>
    {
        event EventHandler<IBeerReviewInfoEventArgs> ReviewUpdate;

        event EventHandler<IBeerReviewInfoEventArgs> ReviewDelete;

        string SuccessMessageText { get; set; }

        bool SuccessMessageVisible { get; set; }
    }
}