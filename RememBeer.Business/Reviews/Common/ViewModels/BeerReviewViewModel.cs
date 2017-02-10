using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RememBeer.Models.Contracts;

namespace RememBeer.Business.Reviews.Common.ViewModels
{
    public class BeerReviewViewModel
    {
        public IBeerReview Review { get; set; }
    }
}
