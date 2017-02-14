﻿using Moq;

using NUnit.Framework;

using Ploeh.AutoFixture;

using RememBeer.Business.Services;
using RememBeer.Data.Repositories.Base;
using RememBeer.Models;
using RememBeer.Tests.Common;

namespace RememBeer.Tests.Business.Services.BreweryServiceTests
{
    [TestFixture]
    public class GetById_Should : TestClassBase
    {
        [Test]
        public void ReturnResultFromRepository()
        {
            var id = this.Fixture.Create<string>();
            var expected = new Brewery();
            var repository = new Mock<IRepository<Brewery>>();
            repository.Setup(r => r.GetById(id))
                      .Returns(expected);

            var service = new BreweryService(repository.Object);

            var result = service.GetById(id);

            Assert.AreSame(expected, result);
        }
    }
}
