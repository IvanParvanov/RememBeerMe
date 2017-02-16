using System.Collections.Generic;

using RememBeer.Business.Logic.Top.Breweries;
using RememBeer.Models.Dtos;

namespace RememBeer.Tests.Business.Mocks
{
    public class MockedTopBreweriesViewModel : TopBreweriesViewModel
    {
        public override IEnumerable<IBreweryRank> Rankings { get; set; }
    }
}
