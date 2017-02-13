using System;

using Moq;

using NUnit.Framework;

using RememBeer.Business.Services;
using RememBeer.Common.Identity.Contracts;
using RememBeer.Common.Identity.Models;
using RememBeer.Data.Repositories.Base;
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
            var userRepository = new Mock<IRepository<ApplicationUser>>().Object;

            var ex = Assert.Throws<ArgumentNullException>(() => new UserService(null, signInManager, userRepository, modelFactory));
        }

        [Test]
        public void ThrowArgumentNullException_WhenIApplicationSignInManagerArgumentIsNull()
        {
            var userManager = new Mock<IApplicationUserManager>().Object;
            var modelFactory = new Mock<IModelFactory>().Object;
            var userRepository = new Mock<IRepository<ApplicationUser>>().Object;

            Assert.Throws<ArgumentNullException>(() => new UserService(userManager, null,userRepository, modelFactory));
        }

        [Test]
        public void ThrowArgumentNullException_WhenIModelFactoryArgumentIsNull()
        {
            var userManager = new Mock<IApplicationUserManager>().Object;
            var signInManager = new Mock<IApplicationSignInManager>().Object;
            var userRepository = new Mock<IRepository<ApplicationUser>>();

            Assert.Throws<ArgumentNullException>(() => new UserService(userManager, signInManager, userRepository.Object, null));
        }

        [Test]
        public void ThrowArgumentNullException_WhenIRepositoryArgumentIsNull()
        {
            var userManager = new Mock<IApplicationUserManager>().Object;
            var signInManager = new Mock<IApplicationSignInManager>().Object;
            var modelFactory = new Mock<IModelFactory>().Object;

            Assert.Throws<ArgumentNullException>(() => new UserService(userManager, signInManager, null, modelFactory));
        }
    }
}
