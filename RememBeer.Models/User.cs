using System.Collections.Generic;

using RememBeer.Common.Identity.Models;

namespace RememBeer.Models
{
    public class User : ApplicationUser
    {
        public User()
        {
            this.BeerReviews = new HashSet<BeerReview>();
        }

        public virtual ICollection<BeerReview> BeerReviews { get; set; }
    }
}
