using System;

using RememBeer.Business.Account.Common.ViewModels;
using RememBeer.Business.Common.Contracts;
using RememBeer.Business.Reviews.My.Contracts;

using WebFormsMvp;

namespace RememBeer.Business.Reviews.Create.Contracts
{
    public interface ICreateReviewView : IView<StatelessViewModel>, IViewWithErrors
    {
        event EventHandler<IBeerReviewInfoEventArgs> OnCreateReview;
    }
}
