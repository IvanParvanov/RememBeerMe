using System;

using WebFormsMvp;

namespace RememBeer.Business.Reviews.My.Contracts
{
    public interface IMyReviewsView : IView<ReviewsViewModel>
    {
        event EventHandler<EventArgs> OnInitialise;

        event EventHandler<IBeerReviewInfoEventArgs> ReviewUpdate;
    }
}