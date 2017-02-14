using System.Threading.Tasks;

using Microsoft.AspNet.Identity;

using Moq;

using NUnit.Framework;

using Ploeh.AutoFixture;

using RememBeer.Business.Services;
using RememBeer.Common.Identity.Contracts;
using RememBeer.Models.Factories;
using RememBeer.Tests.Common;

namespace RememBeer.Tests.Business.Services.UserServiceTests
{
    [TestFixture]
    internal class RemoveAdmin_Should : TestClassBase
    {
        private const string Role = "Admin";

        [Test]
        public void Call_UserManagerAddToRoleAsyncMethodOnceWithCorrectParams()
        {
            var expectedId = this.Fixture.Create<string>();
            var userManager = new Mock<IApplicationUserManager>();
            userManager.Setup(m => m.RemoveFromRoleAsync(expectedId, Role))
                       .Returns(Task.FromResult(IdentityResult.Failed()));

            var signInManager = new Mock<IApplicationSignInManager>();
            var modelFactory = new Mock<IModelFactory>();

            var service = new UserService(userManager.Object,
                                          signInManager.Object,
                                          modelFactory.Object);

            var result = service.RemoveAdmin(expectedId);

            userManager.Verify(m => m.RemoveFromRoleAsync(expectedId, Role), Times.Once);
        }

        [Test]
        public void ReturnResultFrom_UserManagerAddToRoleAsyncMethod()
        {
            var expectedResult = IdentityResult.Failed();
            var expectedId = this.Fixture.Create<string>();
            var userManager = new Mock<IApplicationUserManager>();
            userManager.Setup(m => m.RemoveFromRoleAsync(expectedId, Role))
                       .Returns(Task.FromResult(expectedResult));

            var signInManager = new Mock<IApplicationSignInManager>();
            var modelFactory = new Mock<IModelFactory>();

            var service = new UserService(userManager.Object,
                                          signInManager.Object,
                                          modelFactory.Object);

            var result = service.RemoveAdmin(expectedId);

            Assert.AreSame(expectedResult, result);
        }
    }
}
