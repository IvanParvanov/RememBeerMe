﻿using System;

using RememBeer.Business.Services;

using WebFormsMvp;

namespace RememBeer.Business.Reviews.Common.Presenters
{
    public class BeerReviewPresenter<TView> : Presenter<TView> where TView : class, IView
    {
        private readonly IBeerReviewService reviewService;

        public BeerReviewPresenter(IBeerReviewService reviewService, TView view)
            : base(view)
        {
            if (reviewService == null)
            {
                throw new ArgumentNullException(nameof(reviewService));
            }

            this.reviewService = reviewService;
        }

        protected IBeerReviewService ReviewService
        {
            get { return this.reviewService; }
        }
    }
}
