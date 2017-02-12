using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;

using RememBeer.Business.Top.Beers;
using RememBeer.Models.Dtos;

namespace RememBeer.Tests.Business.Top.Beers.ViewModel
{
    [TestFixture]
    public class Setters_Should
    {
        [Test]
        public void SetPropertiesCorrectly()
        {
            var expectedRankings = new List<IBeerRank>();

            var viewModel = new TopBeersViewModel();
            viewModel.Rankings = expectedRankings;

            Assert.AreSame(expectedRankings, viewModel.Rankings);
        }
    }
}
