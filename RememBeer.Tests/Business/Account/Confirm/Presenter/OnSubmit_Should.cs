using System.Collections.Generic;
using System.Web;

using Microsoft.AspNet.Identity;
using Microsoft.Owin;

using Moq;

using NUnit.Framework;

using RememBeer.Business.Account.Auth;
using RememBeer.Business.Account.Confirm;
using RememBeer.Business.Account.Confirm.Contracts;
using RememBeer.Data.Identity.Contracts;
using RememBeer.Data.Identity.Models;
using RememBeer.Tests.Business.Account.Fakes;

namespace RememBeer.Tests.Business.Account.Confirm.Presenter
{
    [TestFixture]
    public class OnSubmit_Should
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

            var mockedUserManager = new Mock<IApplicationUserManager>();
            mockedUserManager.Setup(m => m.FindByName(Email)).Returns((ApplicationUser)null);
            mockedUserManager.Setup(m => m.IsEmailConfirmed("id")).Returns(false);
            var mockedAuthFactory = new Mock<IAuthFactory>();
            mockedAuthFactory.Setup(f => f.CreateApplicationUserManager(It.IsAny<IOwinContext>()))
                             .Returns(mockedUserManager.Object);
            mockedAuthFactory.Setup(f => f.GetOwinContext(It.IsAny<HttpContextBase>()))
                             .Returns(mockedContext.Object);

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

            var mockedUser = new MockedApplicationUser();
            var mockedUserManager = new Mock<IApplicationUserManager>();

            mockedUserManager.Setup(m => m.FindByName(Email)).Returns(mockedUser);
            mockedUserManager.Setup(m => m.ConfirmEmail(Id, Code)).Returns(new IdentityResult(new List<string>()));

            var mockedAuthFactory = new Mock<IAuthFactory>();
            mockedAuthFactory.Setup(f => f.CreateApplicationUserManager(It.IsAny<IOwinContext>()))
                             .Returns(mockedUserManager.Object);
            mockedAuthFactory.Setup(f => f.GetOwinContext(It.IsAny<HttpContextBase>()))
                             .Returns(mockedContext.Object);

            var presnter = new ConfirmPresenter(mockedAuthFactory.Object, mockedView.Object);

            mockedView.Raise(x => x.OnSubmit += null, mockedView.Object, mockedArgs.Object);

            mockedAuthFactory.Verify(f => f.CreateApplicationUserManager(mockedContext.Object), Times.Once());
            mockedUserManager.Verify(f => f.ConfirmEmail(Id, Code), Times.Once());
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

            var mockedUser = new MockedApplicationUser();
            var mockedUserManager = new Mock<IApplicationUserManager>();

            mockedUserManager.Setup(m => m.FindByName(Email)).Returns(mockedUser);
            mockedUserManager.Setup(m => m.ConfirmEmail(Id, Code)).Returns(IdentityResult.Success);

            var mockedAuthFactory = new Mock<IAuthFactory>();
            mockedAuthFactory.Setup(f => f.CreateApplicationUserManager(It.IsAny<IOwinContext>()))
                             .Returns(mockedUserManager.Object);
            mockedAuthFactory.Setup(f => f.GetOwinContext(It.IsAny<HttpContextBase>()))
                             .Returns(mockedContext.Object);

            var presnter = new ConfirmPresenter(mockedAuthFactory.Object, mockedView.Object);
            mockedView.Raise(x => x.OnSubmit += null, mockedView.Object, mockedArgs.Object);

            mockedAuthFactory.Verify(f => f.CreateApplicationUserManager(mockedContext.Object), Times.Once());
            mockedUserManager.Verify(f => f.ConfirmEmail(Id, Code), Times.Once());
            mockedView.VerifySet(v => v.SuccessPanelVisible = true);
        }
    }
}
