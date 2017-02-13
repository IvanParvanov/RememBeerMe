using System.Collections.Generic;

using RememBeer.Business.Logic.Top.Beers;
using RememBeer.Models.Dtos;

namespace RememBeer.Tests.Business.Mocks
{
    public class MockedTopBeersViewModel : TopBeersViewModel
    {
        public override IEnumerable<IBeerRank> Rankings { get; set; }
    }
}
