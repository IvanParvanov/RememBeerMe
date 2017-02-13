﻿using Microsoft.AspNet.Identity.Owin;

using Moq;

using NUnit.Framework;

using RememBeer.Business.Logic.Account.Login;
using RememBeer.Business.Logic.Account.Login.Contracts;
using RememBeer.Business.Services.Contracts;
using RememBeer.Common.Identity.Contracts;
using RememBeer.Tests.Common.MockedClasses;

namespace RememBeer.Tests.Business.Logic.Account.Login.Presenter
{
    [TestFixture]
    public class OnLogin_Should
    {
        private const string Email = "test@abv.bg";
        private const string Password = "passwordtest@abv.bg";
        private const string ReturnUrlKey = "ReturnUrl";
        private const string ReturnUrl = "asd.aspx";
        private const bool IsPersistent = true;

        [Test]
        public void CallSetViewProperties_WhenLoginFails()
        {
            var mockedView = new Mock<ILoginView>();
            mockedView.SetupSet(v => v.FailureMessage = "");
            mockedView.SetupSet(v => v.ErrorMessageVisible = true);

            var mockedArgs = new Mock<ILoginEventArgs>();
            mockedArgs.Setup(a => a.Email).Returns(Email);
            mockedArgs.Setup(a => a.Password).Returns(Password);
            mockedArgs.Setup(a => a.RememberMe).Returns(IsPersistent);

            var mockedIdentityHelper = new Mock<IIdentityHelper>();

            var userService = new Mock<IUserService>();
            userService.Setup(s => s.PasswordSignIn(Email, Password, IsPersistent))
                       .Returns(SignInStatus.Failure);

            var presenter = new LoginPresenter(userService.Object, mockedIdentityHelper.Object, mockedView.Object);
            mockedView.Raise(x => x.OnLogin += null, mockedView.Object, mockedArgs.Object);

            mockedView.VerifySet(v => v.FailureMessage = It.IsAny<string>());
            mockedView.VerifySet(v => v.ErrorMessageVisible = true);
        }

        [Test]
        public void CallDependenciesMethods_WhenLoginFails()
        {
            var mockedView = new Mock<ILoginView>();

            var mockedArgs = new Mock<ILoginEventArgs>();
            mockedArgs.Setup(a => a.Email).Returns(Email);
            mockedArgs.Setup(a => a.Password).Returns(Password);
            mockedArgs.Setup(a => a.RememberMe).Returns(IsPersistent);

            var userService = new Mock<IUserService>();
            userService.Setup(s => s.PasswordSignIn(Email, Password, IsPersistent))
                       .Returns(SignInStatus.Failure);

            var mockedIdentityHelper = new Mock<IIdentityHelper>();

            var presenter = new LoginPresenter(userService.Object, mockedIdentityHelper.Object, mockedView.Object);
            mockedView.Raise(x => x.OnLogin += null, mockedView.Object, mockedArgs.Object);

            userService.Verify(s => s.PasswordSignIn(Email, Password, IsPersistent), Times.Once());
        }

        [Test]
        public void CallDependenciesMethods_WhenLoginSuccessfull()
        {
            var mockedView = new Mock<ILoginView>();

            var mockedArgs = new Mock<ILoginEventArgs>();
            mockedArgs.Setup(a => a.Email).Returns(Email);
            mockedArgs.Setup(a => a.Password).Returns(Password);
            mockedArgs.Setup(a => a.RememberMe).Returns(IsPersistent);

            var userService = new Mock<IUserService>();
            userService.Setup(s => s.PasswordSignIn(Email, Password, IsPersistent))
                       .Returns(SignInStatus.Success);

            var mockedIdentityHelper = new Mock<IIdentityHelper>();
            var presenter = new LoginPresenter(userService.Object, mockedIdentityHelper.Object, mockedView.Object)
                            {
                                HttpContext = new MockedHttpContextBase()
                            };

            presenter.HttpContext.Request.QueryString.Add(ReturnUrlKey, ReturnUrl);

            mockedView.Raise(x => x.OnLogin += null, mockedView.Object, mockedArgs.Object);

            userService.Verify(f => f.PasswordSignIn(Email, Password, IsPersistent), Times.Once());
        }

        [Test]
        public void CallRedirectWithCorrectParams_WhenSuccessfull()
        {
            var mockedView = new Mock<ILoginView>();

            var mockedArgs = new Mock<ILoginEventArgs>();
            mockedArgs.Setup(a => a.Email).Returns(Email);
            mockedArgs.Setup(a => a.Password).Returns(Password);
            mockedArgs.Setup(a => a.RememberMe).Returns(IsPersistent);

            var userService = new Mock<IUserService>();
            userService.Setup(s => s.PasswordSignIn(Email, Password, IsPersistent))
                       .Returns(SignInStatus.Success);

            var mockedIdentityHelper = new Mock<IIdentityHelper>();
            var presenter = new LoginPresenter(userService.Object, mockedIdentityHelper.Object, mockedView.Object)
            {
                HttpContext = new MockedHttpContextBase()
            };

            presenter.HttpContext.Request.QueryString.Add(ReturnUrlKey, ReturnUrl);

            mockedView.Raise(x => x.OnLogin += null, mockedView.Object, mockedArgs.Object);

            mockedIdentityHelper.Verify(i => i.RedirectToReturnUrl(ReturnUrl, presenter.Response), Times.Once());
        }

        [Test]
        public void CallRedirectWithCorrectParams_WhenLockedOut()
        {
            const string LockoutUrl = "Lockout";

            var mockedView = new Mock<ILoginView>();

            var mockedArgs = new Mock<ILoginEventArgs>();
            mockedArgs.Setup(a => a.Email).Returns(Email);
            mockedArgs.Setup(a => a.Password).Returns(Password);
            mockedArgs.Setup(a => a.RememberMe).Returns(IsPersistent);

            var userService = new Mock<IUserService>();
            userService.Setup(s => s.PasswordSignIn(Email, Password, IsPersistent))
                       .Returns(SignInStatus.LockedOut);

            var mockedIdentityHelper = new Mock<IIdentityHelper>();
            var mockedResponse = new MockedHttpResponse();
            var presenter = new LoginPresenter(userService.Object, mockedIdentityHelper.Object, mockedView.Object)
            {
                HttpContext = new MockedHttpContextBase(mockedResponse)
            };

            mockedView.Raise(x => x.OnLogin += null, mockedView.Object, mockedArgs.Object);

            StringAssert.Contains(LockoutUrl, mockedResponse.RedirectUrl);
        }

        [Test]
        public void CallRedirectWithCorrectParams_WhenRequiresVerification()
        {
            var expectedUrl = $"TwoFactorAuthenticationSignIn?ReturnUrl={ReturnUrl}&RememberMe={IsPersistent}";

            var mockedView = new Mock<ILoginView>();

            var mockedArgs = new Mock<ILoginEventArgs>();
            mockedArgs.Setup(a => a.Email).Returns(Email);
            mockedArgs.Setup(a => a.Password).Returns(Password);
            mockedArgs.Setup(a => a.RememberMe).Returns(IsPersistent);

            var userService = new Mock<IUserService>();
            userService.Setup(s => s.PasswordSignIn(Email, Password, IsPersistent))
                       .Returns(SignInStatus.RequiresVerification);

            var mockedIdentityHelper = new Mock<IIdentityHelper>();
            var mockedResponse = new MockedHttpResponse();
            var presenter = new LoginPresenter(userService.Object, mockedIdentityHelper.Object, mockedView.Object)
            {
                HttpContext = new MockedHttpContextBase(mockedResponse)
            };

            presenter.HttpContext.Request.QueryString.Add(ReturnUrlKey, ReturnUrl);

            mockedView.Raise(x => x.OnLogin += null, mockedView.Object, mockedArgs.Object);

            userService.Verify(f => f.PasswordSignIn(Email, Password, IsPersistent), Times.Once());

            StringAssert.Contains(expectedUrl, mockedResponse.RedirectUrl);
        }
    }
}
