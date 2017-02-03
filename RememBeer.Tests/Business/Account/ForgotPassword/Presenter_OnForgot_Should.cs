﻿using System.Threading.Tasks;

using Microsoft.Owin;

using Moq;

using NUnit.Framework;

using RememBeer.Business.Account.Auth;
using RememBeer.Business.Account.ForgotPassword;
using RememBeer.Business.Account.ForgotPassword.Contracts;
using RememBeer.Data.Identity.Contracts;
using RememBeer.Data.Identity.Models;

using RememBeer.Tests.Business.Account.Fakes;

namespace RememBeer.Tests.Business.Account.ForgotPassword
{
    [TestFixture]
    public class Presenter_OnForgot_Should
    {
        [Test]
        public void CallFactoryCreateApplicationUserManagerMethodOnce()
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
            mockedView.Raise(x => x.OnForgot += null, mockedView.Object, mockedArgs.Object);

            mockedAuthFactory.Verify(x => x.CreateApplicationUserManager(mockedContext.Object), Times.Once());
        }

        [Test]
        public void CallUserManagerFindByNameMethodOnce()
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
            mockedView.Raise(x => x.OnForgot += null, mockedView.Object, mockedArgs.Object);

            mockedUserManager.Verify(x => x.FindByNameAsync(Email), Times.Once());
        }

        [Test]
        public void SetViewProperties_WhenUserIsNotFound()
        {
            const string Email = "test@abv.bg";
            var mockedView = new Mock<IForgotPasswordView>();
            mockedView.SetupSet(v => v.FailureMessage = "");
            mockedView.SetupSet(v => v.ErrorMessageVisible = true);

            var mockedContext = new Mock<IOwinContext>();
            var mockedUserManager = new Mock<IApplicationUserManager>();
            mockedUserManager.Setup(m => m.FindByNameAsync(Email)).Returns(Task.FromResult<ApplicationUser>(null));

            var mockedArgs = new Mock<IForgottenPasswordEventArgs>();

            mockedArgs.Setup(a => a.Email).Returns(Email);
            mockedArgs.Setup(a => a.Context).Returns(mockedContext.Object);

            var mockedAuthFactory = new Mock<IAuthFactory>();
            mockedAuthFactory.Setup(f => f.CreateApplicationUserManager(It.IsAny<IOwinContext>()))
                             .Returns(mockedUserManager.Object);

            new ForgotPasswordPresenter(mockedAuthFactory.Object, mockedView.Object);
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

            var mockedContext = new Mock<IOwinContext>();
            var mockedUserManager = new Mock<IApplicationUserManager>();
            var mockedUser = new MockedApplicationUser();

            mockedUserManager.Setup(m => m.FindByNameAsync(Email)).Returns(Task.FromResult<ApplicationUser>(mockedUser));
            mockedUserManager.Setup(m => m.IsEmailConfirmedAsync(mockedUser.Id)).Returns(Task.FromResult(true));

            var mockedArgs = new Mock<IForgottenPasswordEventArgs>();

            mockedArgs.Setup(a => a.Email).Returns(Email);
            mockedArgs.Setup(a => a.Context).Returns(mockedContext.Object);

            var mockedAuthFactory = new Mock<IAuthFactory>();
            mockedAuthFactory.Setup(f => f.CreateApplicationUserManager(It.IsAny<IOwinContext>()))
                             .Returns(mockedUserManager.Object);

            new ForgotPasswordPresenter(mockedAuthFactory.Object, mockedView.Object);
            mockedView.Raise(x => x.OnForgot += null, mockedView.Object, mockedArgs.Object);

            mockedView.VerifySet(v => v.LoginFormVisible = false);
            mockedView.VerifySet(v => v.DisplayEmailVisible = true);
        }
    }
}
