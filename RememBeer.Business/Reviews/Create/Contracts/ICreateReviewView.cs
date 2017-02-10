using System;

using RememBeer.Business.Account.Common.ViewModels;
using RememBeer.Business.Reviews.My.Contracts;

using WebFormsMvp;

namespace RememBeer.Business.Reviews.Create.Contracts
{
    public interface ICreateReviewView : IView<StatelessViewModel>
    {
        event EventHandler<IBeerReviewInfoEventArgs> OnCreateReview;
    }
}
