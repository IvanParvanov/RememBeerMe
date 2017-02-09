using Microsoft.AspNet.Identity;

using Moq;

using NUnit.Framework;

using RememBeer.Business.Account.Confirm;
using RememBeer.Business.Account.Confirm.Contracts;
using RememBeer.Business.Services.Contracts;

namespace RememBeer.Tests.Business.Account.Confirm.Presenter
{
    [TestFixture]
    public class OnSubmit_Should
    {
        [Test]
        public void ChangeMessagesVisibility_WhenNotSuccessfull()
        {
            var mockedView = new Mock<IConfirmView>();
            mockedView.SetupSet(v => v.SuccessPanelVisible = false);
            mockedView.SetupSet(v => v.ErrorPanelVisible = true);

            var mockedArgs = new Mock<IConfirmEventArgs>();
            mockedArgs.Setup(a => a.UserId).Returns((string)null);
            mockedArgs.Setup(a => a.Code).Returns((string)null);

            var userService = new Mock<IUserService>();

            var presnter = new ConfirmPresenter(userService.Object, mockedView.Object);
            mockedView.Raise(x => x.OnSubmit += null, mockedView.Object, mockedArgs.Object);

            mockedView.VerifySet(v => v.SuccessPanelVisible = false);
            mockedView.VerifySet(v => v.ErrorPanelVisible = true);
        }

        [Test]
        public void ChangeMessagesVisibility_WhenUserIsNotConfirmed()
        {
            const string Email = "test@abv.bg";
            const string Id = "id";
            const string Code = "code";

            var mockedView = new Mock<IConfirmView>();
            mockedView.SetupSet(v => v.SuccessPanelVisible = false);
            mockedView.SetupSet(v => v.ErrorPanelVisible = true);

            var mockedArgs = new Mock<IConfirmEventArgs>();
            mockedArgs.Setup(a => a.UserId).Returns(Id);
            mockedArgs.Setup(a => a.Code).Returns(Code);

            var userService = new Mock<IUserService>();
            userService.Setup(s => s.ConfirmEmail(Id, Code))
                       .Returns(IdentityResult.Failed(Email));

            var presnter = new ConfirmPresenter(userService.Object, mockedView.Object);
            mockedView.Raise(x => x.OnSubmit += null, mockedView.Object, mockedArgs.Object);

            mockedView.VerifySet(v => v.SuccessPanelVisible = false);
            mockedView.VerifySet(v => v.ErrorPanelVisible = true);
        }

        [Test]
        public void CallConfirmEmailMethod_WhenUserDataIsValid()
        {
            const string Id = "id";
            const string Code = "code";

            var mockedView = new Mock<IConfirmView>();

            var mockedArgs = new Mock<IConfirmEventArgs>();
            mockedArgs.Setup(a => a.UserId).Returns(Id);
            mockedArgs.Setup(a => a.Code).Returns(Code);

            var userService = new Mock<IUserService>();
            userService.Setup(s => s.ConfirmEmail(Id, Code))
                       .Returns(IdentityResult.Failed(new string[1]));

            var presnter = new ConfirmPresenter(userService.Object, mockedView.Object);

            mockedView.Raise(x => x.OnSubmit += null, mockedView.Object, mockedArgs.Object);

            userService.Verify(f => f.ConfirmEmail(Id, Code), Times.Once());
        }

        [Test]
        public void ChangeSuccessVisibility_WhenConfirmationSucceeded()
        {
            const string Id = "id";
            const string Code = "code";

            var mockedView = new Mock<IConfirmView>();
            mockedView.SetupSet(v => v.SuccessPanelVisible = true);

            var mockedArgs = new Mock<IConfirmEventArgs>();
            mockedArgs.Setup(a => a.UserId).Returns(Id);
            mockedArgs.Setup(a => a.Code).Returns(Code);

            var userService = new Mock<IUserService>();
            userService.Setup(s => s.ConfirmEmail(Id, Code))
                       .Returns(IdentityResult.Success);

            var presnter = new ConfirmPresenter(userService.Object, mockedView.Object);
            mockedView.Raise(x => x.OnSubmit += null, mockedView.Object, mockedArgs.Object);

            mockedView.VerifySet(v => v.SuccessPanelVisible = true);
        }
    }
}
