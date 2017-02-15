﻿using System;

using Moq;

using NUnit.Framework;

using RememBeer.Business.Services;
using RememBeer.Common.Identity.Contracts;
using RememBeer.Models.Factories;

namespace RememBeer.Tests.Business.Services.UserServiceTests
{
    [TestFixture]
    public class Ctor_Should
    {
        [Test]
        public void ThrowArgumentNullException_WhenIApplicationUserManagerArgumentIsNull()
        {
            var signInManager = new Mock<IApplicationSignInManager>().Object;
            var modelFactory = new Mock<IModelFactory>().Object;

            var ex =
                Assert.Throws<ArgumentNullException>(
                                                     () =>
                                                         new UserService(null,
                                                                         signInManager,
                                                                         modelFactory));
        }

        [Test]
        public void ThrowArgumentNullException_WhenIApplicationSignInManagerArgumentIsNull()
        {
            var userManager = new Mock<IApplicationUserManager>().Object;
            var modelFactory = new Mock<IModelFactory>().Object;

            Assert.Throws<ArgumentNullException>(() => new UserService(userManager, null, modelFactory));
        }

        [Test]
        public void ThrowArgumentNullException_WhenIModelFactoryArgumentIsNull()
        {
            var userManager = new Mock<IApplicationUserManager>().Object;
            var signInManager = new Mock<IApplicationSignInManager>().Object;

            Assert.Throws<ArgumentNullException>(
                                                 () =>
                                                     new UserService(userManager,
                                                                     signInManager,
                                                                     null));
        }
    }
}
