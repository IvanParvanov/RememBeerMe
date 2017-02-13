using System;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;

using Moq;

using NUnit.Framework;

using Ploeh.AutoFixture;

using RememBeer.Business.Services;
using RememBeer.Common.Identity.Contracts;
using RememBeer.Common.Identity.Models;
using RememBeer.Data.Repositories.Base;
using RememBeer.Models.Factories;
using RememBeer.Tests.Common;

namespace RememBeer.Tests.Business.Services.UserServiceTests
{
    [TestFixture]
    public class EnableUser_Should : TestClassBase
    {
        [Test]
        public void CallUserManagerSetLockoutEndDateAsyncMethodOnceWithCorrectParams()
        {
            var expectedId = this.Fixture.Create<string>();
            var userManager = new Mock<IApplicationUserManager>();
            userManager.Setup(m => m.SetLockoutEndDateAsync(expectedId, DateTimeOffset.MinValue))
                       .Returns(Task.FromResult(IdentityResult.Success));

            var signInManager = new Mock<IApplicationSignInManager>();
            var repository = new Mock<IRepository<ApplicationUser>>();
            var modelFactory = new Mock<IModelFactory>();

            var service = new UserService(userManager.Object, signInManager.Object, repository.Object, modelFactory.Object);

            var result = service.EnableUser(expectedId);

            userManager.Verify(m => m.SetLockoutEndDateAsync(expectedId, DateTimeOffset.MinValue), Times.Once);
        }

        [Test]
        public void ReturnResultFrom_UserManagerSetLockoutEndDateAsyncMethod()
        {
            var expectedResult = IdentityResult.Success;
            var id = this.Fixture.Create<string>();

            var userManager = new Mock<IApplicationUserManager>();
            userManager.Setup(m => m.SetLockoutEndDateAsync(It.IsAny<string>(), It.IsAny<DateTimeOffset>()))
                       .Returns(Task.FromResult(expectedResult));

            var signInManager = new Mock<IApplicationSignInManager>();
            var repository = new Mock<IRepository<ApplicationUser>>();
            var modelFactory = new Mock<IModelFactory>();

            var service = new UserService(userManager.Object, signInManager.Object, repository.Object, modelFactory.Object);

            var result = service.EnableUser(id);

            Assert.AreSame(expectedResult, result);
        }
    }
}
