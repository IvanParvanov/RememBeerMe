﻿using Moq;

using NUnit.Framework;

using Ploeh.AutoFixture;

using RememBeer.Common.Identity.Contracts;
using RememBeer.Common.Identity.Models;
using RememBeer.Data.Services;
using RememBeer.Models.Factories;
using RememBeer.Tests.Business.Account.Fakes;
using RememBeer.Tests.Common;

namespace RememBeer.Tests.Data.Services.UserServiceTests
{
    [TestFixture]
    public class FindByName_Should : TestClassBase
    {
        [Test]
        public void CallFindByNameMethodOnce()
        {
            var userName = this.Fixture.Create<string>();

            var mockedUser = new MockedApplicationUser();

            var userManager = new Mock<IApplicationUserManager>();
            userManager.Setup(m => m.FindByName(userName))
                       .Returns(mockedUser);

            var signInManager = new Mock<IApplicationSignInManager>();
            var modelFactory = new Mock<IModelFactory>();

            var service = new UserService(userManager.Object,
                                          signInManager.Object,
                                          modelFactory.Object);

            var result = service.FindByName(userName);

            userManager.Verify(m => m.FindByName(userName), Times.Once);
        }

        [Test]
        public void ReturnValueFromUserManager_WhenUserIsFound()
        {
            var userName = this.Fixture.Create<string>();

            var mockedUser = new MockedApplicationUser();

            var userManager = new Mock<IApplicationUserManager>();
            userManager.Setup(m => m.FindByName(userName))
                       .Returns(mockedUser);

            var signInManager = new Mock<IApplicationSignInManager>();
            var modelFactory = new Mock<IModelFactory>();

            var service = new UserService(userManager.Object,
                                          signInManager.Object,
                                          modelFactory.Object);

            var result = service.FindByName(userName);

            Assert.AreSame(mockedUser, result);
        }

        [Test]
        public void ReturnValueFromUserManager_WhenUserIsNotFound()
        {
            var userName = this.Fixture.Create<string>();
            var expectedResult = (ApplicationUser)null;
            var userManager = new Mock<IApplicationUserManager>();
            userManager.Setup(m => m.FindByName(userName))
                       .Returns(expectedResult);

            var signInManager = new Mock<IApplicationSignInManager>();
            var modelFactory = new Mock<IModelFactory>();

            var service = new UserService(userManager.Object,
                                          signInManager.Object,
                                          modelFactory.Object);

            var result = service.FindByName(userName);

            Assert.AreSame(expectedResult, result);
        }
    }
}
