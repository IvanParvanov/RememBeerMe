using Moq;

using NUnit.Framework;

using Ploeh.AutoFixture;

using RememBeer.Common.Identity.Contracts;
using RememBeer.Common.Identity.Models;
using RememBeer.Data.Repositories.Base;
using RememBeer.Data.Services;
using RememBeer.Models.Factories;
using RememBeer.Tests.Common;

namespace RememBeer.Tests.Data.Services.UserServiceTests
{
    [TestFixture]
    public class IsEmailConfirmed_Should : TestClassBase
    {
        [Test]
        public void CallFindByNameMethodOnce()
        {
            var userId = this.Fixture.Create<string>();
            var expectedResult = this.Fixture.Create<bool>();

            var userManager = new Mock<IApplicationUserManager>();
            userManager.Setup(m => m.IsEmailConfirmed(userId))
                       .Returns(expectedResult);

            var signInManager = new Mock<IApplicationSignInManager>();
            var modelFactory = new Mock<IModelFactory>();
            var userRepository = new Mock<IRepository<ApplicationUser>>();

            var service = new UserService(userManager.Object,
                                          signInManager.Object,
                                          userRepository.Object,
                                          modelFactory.Object);

            var result = service.IsEmailConfirmed(userId);

            userManager.Verify(m => m.IsEmailConfirmed(userId), Times.Once);
        }

        [Test]
        public void ReturnValueFromUserManager_WhenUserIsFound()
        {
            var userId = this.Fixture.Create<string>();
            var expectedResult = this.Fixture.Create<bool>();

            var userManager = new Mock<IApplicationUserManager>();
            userManager.Setup(m => m.IsEmailConfirmed(userId))
                       .Returns(expectedResult);

            var signInManager = new Mock<IApplicationSignInManager>();
            var modelFactory = new Mock<IModelFactory>();
            var userRepository = new Mock<IRepository<ApplicationUser>>();

            var service = new UserService(userManager.Object,
                                          signInManager.Object,
                                          userRepository.Object,
                                          modelFactory.Object);

            var result = service.IsEmailConfirmed(userId);

            Assert.AreEqual(expectedResult, result);
        }
    }
}
