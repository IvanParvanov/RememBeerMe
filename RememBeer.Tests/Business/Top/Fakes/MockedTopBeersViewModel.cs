using System.Collections.Generic;

using RememBeer.Business.Top.Beers;
using RememBeer.Models.Dtos;

namespace RememBeer.Tests.Business.Top.Fakes
{
    public class MockedTopBeersViewModel : TopBeersViewModel
    {
        public override IEnumerable<IBeerRank> Rankings { get; set; }
    }
}
