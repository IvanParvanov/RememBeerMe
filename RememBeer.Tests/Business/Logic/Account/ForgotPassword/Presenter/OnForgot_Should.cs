using Moq;

using NUnit.Framework;

using RememBeer.Business.Logic.Account.ForgotPassword;
using RememBeer.Business.Logic.Account.ForgotPassword.Contracts;
using RememBeer.Business.Services.Contracts;
using RememBeer.Common.Identity.Contracts;

namespace RememBeer.Tests.Business.Logic.Account.ForgotPassword.Presenter
{
    [TestFixture]
    public class OnForgot_Should
    {
        [Test]
        public void CallFindByNameMethodOnce()
        {
            const string Email = "test@abv.bg";
            var mockedView = new Mock<IForgotPasswordView>();
            var mockedArgs = new Mock<IForgotPasswordEventArgs>();
            mockedArgs.Setup(a => a.Email).Returns(Email);

            var mockedUser = new Mock<IApplicationUser>();
            var userService = new Mock<IUserService>();
            userService.Setup(s => s.FindByName(Email))
                       .Returns(mockedUser.Object);

            new ForgotPasswordPresenter(userService.Object, mockedView.Object);
            mockedView.Raise(x => x.OnForgot += null, mockedView.Object, mockedArgs.Object);

            userService.Verify(x => x.FindByName(Email), Times.Once());
        }

        [Test]
        public void SetViewProperties_WhenUserIsNotFound()
        {
            const string Email = "test@abv.bg";
            var mockedView = new Mock<IForgotPasswordView>();
            mockedView.SetupSet(v => v.FailureMessage = "");
            mockedView.SetupSet(v => v.ErrorMessageVisible = true);

            var mockedArgs = new Mock<IForgotPasswordEventArgs>();
            mockedArgs.Setup(a => a.Email).Returns(Email);

            var userService = new Mock<IUserService>();
            userService.Setup(s => s.FindByName(Email))
                       .Returns((IApplicationUser)null);

            new ForgotPasswordPresenter(userService.Object, mockedView.Object);
            mockedView.Raise(x => x.OnForgot += null, mockedView.Object, mockedArgs.Object);

            mockedView.VerifySet(v => v.FailureMessage = It.IsAny<string>());
            mockedView.VerifySet(v => v.ErrorMessageVisible = true);
        }

        [Test]
        public void SetViewProperties_WhenUserIsFoundButNotConfirmed()
        {
            const string Email = "test@abv.bg";
            var mockedView = new Mock<IForgotPasswordView>();
            mockedView.SetupSet(v => v.FailureMessage = "");
            mockedView.SetupSet(v => v.ErrorMessageVisible = true);

            var mockedArgs = new Mock<IForgotPasswordEventArgs>();
            mockedArgs.Setup(a => a.Email).Returns(Email);

            var mockedUser = new Mock<IApplicationUser>();
            var userService = new Mock<IUserService>();
            userService.Setup(s => s.FindByName(Email))
                       .Returns(mockedUser.Object);
            userService.Setup(s => s.IsEmailConfirmed(Email)).Returns(false);

            new ForgotPasswordPresenter(userService.Object, mockedView.Object);
            mockedView.Raise(x => x.OnForgot += null, mockedView.Object, mockedArgs.Object);

            mockedView.VerifySet(v => v.FailureMessage = It.IsAny<string>());
            mockedView.VerifySet(v => v.ErrorMessageVisible = true);
        }

        [Test]
        public void SetViewProperties_WhenUserIsFound()
        {
            const string Email = "test@abv.bg";
            var mockedView = new Mock<IForgotPasswordView>();
            mockedView.SetupSet(v => v.LoginFormVisible = false);
            mockedView.SetupSet(v => v.DisplayEmailVisible = true);

            var mockedArgs = new Mock<IForgotPasswordEventArgs>();
            mockedArgs.Setup(a => a.Email).Returns(Email);

            var mockedUser = new Mock<IApplicationUser>();
            var userService = new Mock<IUserService>();
            userService.Setup(s => s.FindByName(Email))
                       .Returns(mockedUser.Object);
            userService.Setup(s => s.IsEmailConfirmed(It.IsAny<string>()))
                       .Returns(true);

            new ForgotPasswordPresenter(userService.Object, mockedView.Object);
            mockedView.Raise(x => x.OnForgot += null, mockedView.Object, mockedArgs.Object);

            mockedView.VerifySet(v => v.LoginFormVisible = false);
            mockedView.VerifySet(v => v.DisplayEmailVisible = true);
        }
    }
}
