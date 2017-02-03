using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNet.Identity;
using Microsoft.Owin;

using Moq;

using NUnit.Framework;

using RememBeer.Business.Account.Auth;
using RememBeer.Business.Account.Confirm;
using RememBeer.Business.Account.Confirm.Contracts;
using RememBeer.Data;
using RememBeer.Data.Identity;
using RememBeer.Data.Identity.Contracts;
using RememBeer.Data.Identity.Models;
using RememBeer.Tests.Business.Account.Fakes;

namespace RememBeer.Tests.Business.Account.Confirm
{
    [TestFixture]
    public class Presenter_OnSubmit_Should
    {
        [Test]
        public void ChangeMessagesVisibility_WhenNotSuccessfull()
        {
            const string Email = "test@abv.bg";
            var mockedView = new Mock<IConfirmView>();
            mockedView.SetupSet(v => v.SuccessPanelVisible = false);
            mockedView.SetupSet(v => v.ErrorPanelVisible = true);

            var mockedContext = new Mock<IOwinContext>();

            var mockedArgs = new Mock<IConfirmEventArgs>();
            mockedArgs.Setup(a => a.UserId).Returns((string)null);
            mockedArgs.Setup(a => a.Code).Returns((string)null);
            mockedArgs.Setup(a => a.Context).Returns(mockedContext.Object);

            var mockedUserManager = new Mock<IApplicationUserManager>();
            mockedUserManager.Setup(m => m.FindByNameAsync(Email)).Returns(Task.FromResult<ApplicationUser>(null));
            mockedUserManager.Setup(m => m.IsEmailConfirmedAsync("id")).Returns(Task.FromResult(false));
            var mockedAuthFactory = new Mock<IAuthFactory>();
            mockedAuthFactory.Setup(f => f.CreateApplicationUserManager(It.IsAny<IOwinContext>()))
                             .Returns(mockedUserManager.Object);

            var presnter = new ConfirmPresenter(mockedAuthFactory.Object, mockedView.Object);

            mockedView.Raise(x => x.OnSubmit += null, mockedView.Object, mockedArgs.Object);

            mockedView.VerifySet(v => v.SuccessPanelVisible = false);
            mockedView.VerifySet(v => v.ErrorPanelVisible = true);
        }

        [Test]
        public void CallFactoryAndManagerMethods_WhenFailedConfirmation()
        {
            const string Email = "test@abv.bg";
            const string Id = "id";
            const string Code = "code";

            var mockedView = new Mock<IConfirmView>();
            var mockedContext = new Mock<IOwinContext>();

            var mockedArgs = new Mock<IConfirmEventArgs>();
            mockedArgs.Setup(a => a.UserId).Returns(Id);
            mockedArgs.Setup(a => a.Code).Returns(Code);
            mockedArgs.Setup(a => a.Context).Returns(mockedContext.Object);

            var mockedUser = new MockedApplicationUser();
            var mockedUserManager = new Mock<IApplicationUserManager>();

            mockedUserManager.Setup(m => m.FindByNameAsync(Email)).Returns(Task.FromResult<ApplicationUser>(mockedUser));
            mockedUserManager.Setup(m => m.ConfirmEmailAsync(Id, Code)).Returns(Task.FromResult(new IdentityResult(new List<string>())));

            var mockedAuthFactory = new Mock<IAuthFactory>();
            mockedAuthFactory.Setup(f => f.CreateApplicationUserManager(It.IsAny<IOwinContext>()))
                             .Returns(mockedUserManager.Object);

            var presnter = new ConfirmPresenter(mockedAuthFactory.Object, mockedView.Object);

            mockedView.Raise(x => x.OnSubmit += null, mockedView.Object, mockedArgs.Object);

            mockedAuthFactory.Verify(f => f.CreateApplicationUserManager(mockedContext.Object), Times.Once());
            mockedUserManager.Verify(f => f.ConfirmEmailAsync(Id, Code), Times.Once());
        }

        [Test]
        public void CallFactoryAndManagerMethodsAndChangeSuccessVisibility_WhenConfirmationSucceeded()
        {
            const string Email = "test@abv.bg";
            const string Id = "id";
            const string Code = "code";

            var mockedView = new Mock<IConfirmView>();
            mockedView.SetupSet(v => v.SuccessPanelVisible = true);
            var mockedContext = new Mock<IOwinContext>();

            var mockedArgs = new Mock<IConfirmEventArgs>();
            mockedArgs.Setup(a => a.UserId).Returns(Id);
            mockedArgs.Setup(a => a.Code).Returns(Code);
            mockedArgs.Setup(a => a.Context).Returns(mockedContext.Object);

            var mockedUser = new MockedApplicationUser();
            var mockedUserManager = new Mock<IApplicationUserManager>();

            mockedUserManager.Setup(m => m.FindByNameAsync(Email)).Returns(Task.FromResult<ApplicationUser>(mockedUser));
            mockedUserManager.Setup(m => m.ConfirmEmailAsync(Id, Code)).Returns(Task.FromResult(IdentityResult.Success));

            var mockedAuthFactory = new Mock<IAuthFactory>();
            mockedAuthFactory.Setup(f => f.CreateApplicationUserManager(It.IsAny<IOwinContext>()))
                             .Returns(mockedUserManager.Object);


            var presnter = new ConfirmPresenter(mockedAuthFactory.Object, mockedView.Object);
            mockedView.Raise(x => x.OnSubmit += null, mockedView.Object, mockedArgs.Object);

            mockedAuthFactory.Verify(f => f.CreateApplicationUserManager(mockedContext.Object), Times.Once());
            mockedUserManager.Verify(f => f.ConfirmEmailAsync(Id, Code), Times.Once());
            mockedView.VerifySet(v => v.SuccessPanelVisible = true);
        }
    }
}
