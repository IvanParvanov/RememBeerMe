using System;

using Moq;

using NUnit.Framework;

using RememBeer.Business.Common.Contracts;
using RememBeer.Business.Top.Beers;

namespace RememBeer.Tests.Business.Top.Beers.Presenter
{
    [TestFixture]
   public class Ctor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenBeerServiceIsNull()
        {
            var mockedView = new Mock<IInitializableView<TopBeersViewModel>>();

            Assert.Throws<ArgumentNullException>(() => new TopBeersPresenter(null, mockedView.Object));
        }
    }
}
