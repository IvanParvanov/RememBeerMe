using System.Collections.Generic;

using RememBeer.Models;
using RememBeer.Models.Contracts;

namespace RememBeer.Business.Reviews.My
{
    public class ReviewsViewModel
    {
        public ReviewsViewModel()
        {
            this.Reviews = new HashSet<IBeerReview>();
        }

        public IEnumerable<IBeerReview> Reviews { get; set; }
    }
}
