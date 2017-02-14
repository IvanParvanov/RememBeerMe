using System;

using RememBeer.Business.Logic.Common.Contracts;

namespace RememBeer.Business.Logic.Reviews.My.Contracts
{
    public interface IMyReviewsView : IInitializableView<ReviewsViewModel>
    {
        event EventHandler<IBeerReviewInfoEventArgs> ReviewUpdate;

        event EventHandler<IBeerReviewInfoEventArgs> ReviewDelete;

        string SuccessMessageText { get; set; }

        bool SuccessMessageVisible { get; set; }
    }
}
