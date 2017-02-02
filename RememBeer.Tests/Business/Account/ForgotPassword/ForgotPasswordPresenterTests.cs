using System.Threading.Tasks;

using Microsoft.Owin;

using Moq;

using NUnit.Framework;

using RememBeer.Business.Account.Auth;
using RememBeer.Business.Account.ForgotPassword;
using RememBeer.Business.Account.ForgotPassword.Contracts;
using RememBeer.Data;

namespace RememBeer.Tests.Business.Account.ForgotPassword
{
    [TestFixture]
    public class ForgotPasswordPresenterTests
    {
        [Test]
        public void OnForgot_ShouldCallFactoryCreateApplicationUserManagerMethodOnce()
        {
            const string Email = "test@abv.bg";
            var mockedView = new Mock<IForgotPasswordView>();

            var mockedContext = new Mock<IOwinContext>();
            var mockedUserManager = new Mock<IApplicationUserManager>();
            mockedUserManager.Setup(m => m.FindByNameAsync(Email)).Returns(Task.FromResult<ApplicationUser>(null));
            mockedUserManager.Setup(m => m.IsEmailConfirmedAsync("id")).Returns(Task.FromResult(false));

            var mockedArgs = new Mock<IForgottenPasswordEventArgs>();

            mockedArgs.Setup(a => a.Email).Returns(Email);
            mockedArgs.Setup(a => a.Context).Returns(mockedContext.Object);

            var mockedAuthFactory = new Mock<IAuthFactory>();
            mockedAuthFactory.Setup(f => f.CreateApplicationUserManager(It.IsAny<IOwinContext>()))
                             .Returns(mockedUserManager.Object);

            new ForgotPasswordPresenter(mockedAuthFactory.Object, mockedView.Object);
            mockedView.Raise(x => x.OnForgot += null, mockedView.Object, new ForgottenPasswordEventArgs(mockedContext.Object, Email));

            mockedAuthFactory.Verify(x => x.CreateApplicationUserManager(mockedContext.Object), Times.Once());
        }

        [Test]
        public void OnForgot_ShouldCallUserManagerFindByNameMethodOnce()
        {
            const string Email = "test@abv.bg";
            var mockedView = new Mock<IForgotPasswordView>();

            var mockedContext = new Mock<IOwinContext>();
            var mockedUserManager = new Mock<IApplicationUserManager>();
            mockedUserManager.Setup(m => m.FindByNameAsync(Email)).Returns(Task.FromResult<ApplicationUser>(null));
            mockedUserManager.Setup(m => m.IsEmailConfirmedAsync("id")).Returns(Task.FromResult(false));

            var mockedArgs = new Mock<IForgottenPasswordEventArgs>();

            mockedArgs.Setup(a => a.Email).Returns(Email);
            mockedArgs.Setup(a => a.Context).Returns(mockedContext.Object);

            var mockedAuthFactory = new Mock<IAuthFactory>();
            mockedAuthFactory.Setup(f => f.CreateApplicationUserManager(It.IsAny<IOwinContext>()))
                             .Returns(mockedUserManager.Object);

            new ForgotPasswordPresenter(mockedAuthFactory.Object, mockedView.Object);
            mockedView.Raise(x => x.OnForgot += null, mockedView.Object, new ForgottenPasswordEventArgs(mockedContext.Object, Email));

            mockedUserManager.Verify(x => x.FindByNameAsync(Email), Times.Once());
        }

        [Test]
        public void OnForgot_ShouldSetViewProperties_WhenUserIsFound()
        {
            const string Email = "test@abv.bg";
            var mockedView = new Mock<IForgotPasswordView>();
            mockedView.SetupSet(v => v.FailureMessage = "");
            mockedView.SetupSet(v => v.ErrorMessageVisible = true);

            var mockedContext = new Mock<IOwinContext>();
            var mockedUserManager = new Mock<IApplicationUserManager>();
            mockedUserManager.Setup(m => m.FindByNameAsync(Email)).Returns(Task.FromResult<ApplicationUser>(null));
            mockedUserManager.Setup(m => m.IsEmailConfirmedAsync("id")).Returns(Task.FromResult(false));

            var mockedArgs = new Mock<IForgottenPasswordEventArgs>();

            mockedArgs.Setup(a => a.Email).Returns(Email);
            mockedArgs.Setup(a => a.Context).Returns(mockedContext.Object);

            var mockedAuthFactory = new Mock<IAuthFactory>();
            mockedAuthFactory.Setup(f => f.CreateApplicationUserManager(It.IsAny<IOwinContext>()))
                             .Returns(mockedUserManager.Object);

            new ForgotPasswordPresenter(mockedAuthFactory.Object, mockedView.Object);
            mockedView.Raise(x => x.OnForgot += null, mockedView.Object, new ForgottenPasswordEventArgs(mockedContext.Object, Email));

            mockedView.VerifySet(v => v.FailureMessage = It.IsAny<string>());
            mockedView.VerifySet(v => v.ErrorMessageVisible = true);
        }
    }
}
