using System;

using RememBeer.Business.Logic.Common.EventArgs.Contracts;
using RememBeer.Business.Logic.Reviews.Common.ViewModels;

using WebFormsMvp;

namespace RememBeer.Business.Logic.Reviews.Default.Contracts
{
    public interface IReviewDetailsView : IView<BeerReviewViewModel>
    {
        bool NotFoundVisible { get; set; }

        event EventHandler<IIdentifiableEventArgs<int>> OnInitialise;
    }
}
