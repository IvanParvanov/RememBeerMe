﻿using System;

using RememBeer.Business.Logic.Common.EventArgs.Contracts;

using WebFormsMvp;

namespace RememBeer.Business.Logic.Reviews.My.Contracts
{
    public interface IMyReviewsView : IView<ReviewsViewModel>
    {
        /// <summary>
        /// Triggered when a the view is being initialized.
        /// </summary>
        event EventHandler<IPaginationEventArgs> Initialized; 

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
