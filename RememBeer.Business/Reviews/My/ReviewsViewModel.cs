using System.Collections.Generic;

using RememBeer.Models;

namespace RememBeer.Business.Reviews.My
{
    public class ReviewsViewModel
    {
        public ReviewsViewModel()
        {
            this.Reviews = new HashSet<BeerReview>();
        }

        public ICollection<BeerReview> Reviews { get; set; }
    }
}
