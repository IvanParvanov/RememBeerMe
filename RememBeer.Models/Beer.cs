using System.Collections.Generic;

namespace RememBeer.Models
{
    public class Beer : Identifiable
    {
        public Beer()
        {
            this.Reviews = new HashSet<BeerReview>();
        }

        public BeerType Type { get; set; }

        public virtual Brewery Brewery { get; set; }

        public virtual ICollection<BeerReview> Reviews { get; set; }
    }
}
