using System;

using RememBeer.Business.Common.EventArgs.Contracts;
using RememBeer.Business.Reviews.Common.ViewModels;

using WebFormsMvp;

namespace RememBeer.Business.Reviews.Default.Contracts
{
    public interface IReviewDetailsView : IView<BeerReviewViewModel>
    {
        bool NotFoundVisible { get; set; }

        event EventHandler<IIdentifiableEventArgs<int>> OnInitialise;
    }
}
