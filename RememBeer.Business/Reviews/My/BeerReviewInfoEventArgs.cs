using System;

using RememBeer.Business.Reviews.My.Contracts;
using RememBeer.Models;

namespace RememBeer.Business.Reviews.My
{
    public class BeerReviewInfoEventArgs : EventArgs, IBeerReviewInfoEventArgs
    {
        public BeerReviewInfoEventArgs(BeerReview beerReview)
        {
            this.BeerReview = beerReview;
        }

        public BeerReviewInfoEventArgs(BeerReview beerReview, byte[] image)
            :this(beerReview)
        {
            this.Image = image;
        }

        public BeerReview BeerReview { get; set; }

        public byte[] Image { get; set; }
    }
}
