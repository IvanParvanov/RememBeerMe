using System.Collections.Generic;

using RememBeer.Models.Dtos;

namespace RememBeer.Business.Top.Beers
{
    public class TopBeersViewModel
    {
        public virtual IEnumerable<IBeerRank> Rankings { get; set; }
    }
}
