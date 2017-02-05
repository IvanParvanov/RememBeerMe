using System.Web;

using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

using Moq;

using NUnit.Framework;

using RememBeer.Business.Account.Auth;
using RememBeer.Business.Account.Login;
using RememBeer.Business.Account.Login.Contracts;
using RememBeer.Data.Identity.Contracts;
using RememBeer.Tests.Common.MockedClasses;

namespace RememBeer.Tests.Business.Account.Login.Presenter
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

            var mockedContext = new Mock<IOwinContext>();
            var mockedUserManager = new Mock<IApplicationSignInManager>();
            mockedUserManager.Setup(m => m.PasswordSignIn(Email, Password, IsPersistent)).Returns(SignInStatus.Failure);

            var mockedArgs = new Mock<ILoginEventArgs>();
            mockedArgs.Setup(a => a.Email).Returns(Email);
            mockedArgs.Setup(a => a.Password).Returns(Password);
            mockedArgs.Setup(a => a.RememberMe).Returns(IsPersistent);
           

            var mockedAuthFactory = new Mock<IAuthProvider>();
            mockedAuthFactory.Setup(f => f.CreateApplicationSignInManager(mockedContext.Object))
                             .Returns(mockedUserManager.Object);
            mockedAuthFactory.Setup(f => f.CreateOwinContext(It.IsAny<HttpContextBase>()))
                             .Returns(mockedContext.Object);

            var mockedIdentityHelper = new Mock<IIdentityHelper>();

            var presenter = new LoginPresenter(mockedAuthFactory.Object, mockedIdentityHelper.Object, mockedView.Object);
            mockedView.Raise(x => x.OnLogin += null, mockedView.Object, mockedArgs.Object);

            mockedView.VerifySet(v => v.FailureMessage = It.IsAny<string>());
            mockedView.VerifySet(v => v.ErrorMessageVisible = true);
        }

        [Test]
        public void CallDependenciesMethods_WhenLoginFails()
        {
            var mockedView = new Mock<ILoginView>();

            var mockedContext = new Mock<IOwinContext>();
            var mockedUserManager = new Mock<IApplicationSignInManager>();
            mockedUserManager.Setup(m => m.PasswordSignIn(Email, Password, IsPersistent)).Returns(SignInStatus.Failure);

            var mockedArgs = new Mock<ILoginEventArgs>();
            mockedArgs.Setup(a => a.Email).Returns(Email);
            mockedArgs.Setup(a => a.Password).Returns(Password);
            mockedArgs.Setup(a => a.RememberMe).Returns(IsPersistent);

            var mockedAuthFactory = new Mock<IAuthProvider>();
            mockedAuthFactory.Setup(f => f.CreateApplicationSignInManager(It.IsAny<IOwinContext>()))
                             .Returns(mockedUserManager.Object);
            mockedAuthFactory.Setup(f => f.CreateOwinContext(It.IsAny<HttpContextBase>()))
                             .Returns(mockedContext.Object);

            var mockedIdentityHelper = new Mock<IIdentityHelper>();

            var presenter = new LoginPresenter(mockedAuthFactory.Object, mockedIdentityHelper.Object, mockedView.Object);
            mockedView.Raise(x => x.OnLogin += null, mockedView.Object, mockedArgs.Object);

            mockedAuthFactory.Verify(f => f.CreateApplicationSignInManager(mockedContext.Object), Times.Once());
            mockedUserManager.Verify(f => f.PasswordSignIn(Email, Password, IsPersistent), Times.Once());
        }

        [Test]
        public void CallDependenciesMethods_WhenLoginSuccessfull()
        {
            var mockedView = new Mock<ILoginView>();

            var mockedContext = new Mock<IOwinContext>();
            var mockedUserManager = new Mock<IApplicationSignInManager>();
            mockedUserManager.Setup(m => m.PasswordSignIn(Email, Password, IsPersistent)).Returns(SignInStatus.Success);

            var mockedArgs = new Mock<ILoginEventArgs>();
            mockedArgs.Setup(a => a.Email).Returns(Email);
            mockedArgs.Setup(a => a.Password).Returns(Password);
            mockedArgs.Setup(a => a.RememberMe).Returns(IsPersistent);

            var mockedAuthFactory = new Mock<IAuthProvider>();
            mockedAuthFactory.Setup(f => f.CreateApplicationSignInManager(It.IsAny<IOwinContext>()))
                             .Returns(mockedUserManager.Object);
            mockedAuthFactory.Setup(f => f.CreateOwinContext(It.IsAny<HttpContextBase>()))
                             .Returns(mockedContext.Object);

            var mockedIdentityHelper = new Mock<IIdentityHelper>();
            var presenter = new LoginPresenter(mockedAuthFactory.Object, mockedIdentityHelper.Object, mockedView.Object)
                            {
                                HttpContext = new MockedHttpContextBase()
                            };

            presenter.HttpContext.Request.QueryString.Add(ReturnUrlKey, ReturnUrl);

            mockedView.Raise(x => x.OnLogin += null, mockedView.Object, mockedArgs.Object);

            mockedAuthFactory.Verify(f => f.CreateApplicationSignInManager(mockedContext.Object), Times.Once());
            mockedUserManager.Verify(f => f.PasswordSignIn(Email, Password, IsPersistent), Times.Once());
            mockedIdentityHelper.Verify(i => i.RedirectToReturnUrl(ReturnUrl, presenter.Response), Times.Once());
        }

        [Test]
        public void CallRedirectWithCorrectParams_WhenSuccessfull()
        {
            var mockedView = new Mock<ILoginView>();

            var mockedContext = new Mock<IOwinContext>();
            var mockedUserManager = new Mock<IApplicationSignInManager>();
            mockedUserManager.Setup(m => m.PasswordSignIn(Email, Password, IsPersistent)).Returns(SignInStatus.Success);

            var mockedArgs = new Mock<ILoginEventArgs>();
            mockedArgs.Setup(a => a.Email).Returns(Email);
            mockedArgs.Setup(a => a.Password).Returns(Password);
            mockedArgs.Setup(a => a.RememberMe).Returns(IsPersistent);

            var mockedAuthFactory = new Mock<IAuthProvider>();
            mockedAuthFactory.Setup(f => f.CreateApplicationSignInManager(It.IsAny<IOwinContext>()))
                             .Returns(mockedUserManager.Object);
            mockedAuthFactory.Setup(f => f.CreateOwinContext(It.IsAny<HttpContextBase>()))
                             .Returns(mockedContext.Object);

            var mockedIdentityHelper = new Mock<IIdentityHelper>();
            var presenter = new LoginPresenter(mockedAuthFactory.Object, mockedIdentityHelper.Object, mockedView.Object)
            {
                HttpContext = new MockedHttpContextBase()
            };

            presenter.HttpContext.Request.QueryString.Add(ReturnUrlKey, ReturnUrl);

            mockedView.Raise(x => x.OnLogin += null, mockedView.Object, mockedArgs.Object);
            mockedAuthFactory.Verify(f => f.CreateApplicationSignInManager(mockedContext.Object), Times.Once());
            mockedUserManager.Verify(f => f.PasswordSignIn(Email, Password, IsPersistent), Times.Once());
            mockedIdentityHelper.Verify(i => i.RedirectToReturnUrl(ReturnUrl, presenter.Response), Times.Once());
        }

        [Test]
        public void CallRedirectWithCorrectParams_WhenLockedOut()
        {
            const string LockoutUrl = "/Account/Lockout";

            var mockedView = new Mock<ILoginView>();

            var mockedContext = new Mock<IOwinContext>();
            var mockedUserManager = new Mock<IApplicationSignInManager>();
            mockedUserManager.Setup(m => m.PasswordSignIn(Email, Password, IsPersistent)).Returns(SignInStatus.LockedOut);

            var mockedArgs = new Mock<ILoginEventArgs>();
            mockedArgs.Setup(a => a.Email).Returns(Email);
            mockedArgs.Setup(a => a.Password).Returns(Password);
            mockedArgs.Setup(a => a.RememberMe).Returns(IsPersistent);

            var mockedAuthFactory = new Mock<IAuthProvider>();
            mockedAuthFactory.Setup(f => f.CreateApplicationSignInManager(It.IsAny<IOwinContext>()))
                             .Returns(mockedUserManager.Object);
            mockedAuthFactory.Setup(f => f.CreateOwinContext(It.IsAny<HttpContextBase>()))
                             .Returns(mockedContext.Object);

            var mockedIdentityHelper = new Mock<IIdentityHelper>();
            var mockedResponse = new MockedHttpResponse();
            var presenter = new LoginPresenter(mockedAuthFactory.Object, mockedIdentityHelper.Object, mockedView.Object)
            {
                HttpContext = new MockedHttpContextBase(mockedResponse)
            };

            mockedView.Raise(x => x.OnLogin += null, mockedView.Object, mockedArgs.Object);

            mockedAuthFactory.Verify(f => f.CreateApplicationSignInManager(mockedContext.Object), Times.Once());
            mockedUserManager.Verify(f => f.PasswordSignIn(Email, Password, IsPersistent), Times.Once());
            Assert.AreEqual(LockoutUrl, mockedResponse.RedirectUrl);
        }

        [Test]
        public void CallRedirectWithCorrectParams_WhenRequiresVerification()
        {
            var expectedUrl = $"/Account/TwoFactorAuthenticationSignIn?ReturnUrl={ReturnUrl}&RememberMe={IsPersistent}";

            var mockedView = new Mock<ILoginView>();

            var mockedContext = new Mock<IOwinContext>();
            var mockedUserManager = new Mock<IApplicationSignInManager>();
            mockedUserManager.Setup(m => m.PasswordSignIn(Email, Password, IsPersistent)).Returns(SignInStatus.RequiresVerification);

            var mockedArgs = new Mock<ILoginEventArgs>();
            mockedArgs.Setup(a => a.Email).Returns(Email);
            mockedArgs.Setup(a => a.Password).Returns(Password);
            mockedArgs.Setup(a => a.RememberMe).Returns(IsPersistent);

            var mockedAuthFactory = new Mock<IAuthProvider>();
            mockedAuthFactory.Setup(f => f.CreateApplicationSignInManager(It.IsAny<IOwinContext>()))
                             .Returns(mockedUserManager.Object);
            mockedAuthFactory.Setup(f => f.CreateOwinContext(It.IsAny<HttpContextBase>()))
                             .Returns(mockedContext.Object);

            var mockedIdentityHelper = new Mock<IIdentityHelper>();
            var mockedResponse = new MockedHttpResponse();
            var presenter = new LoginPresenter(mockedAuthFactory.Object, mockedIdentityHelper.Object, mockedView.Object)
            {
                HttpContext = new MockedHttpContextBase(mockedResponse)
            };

            presenter.HttpContext.Request.QueryString.Add(ReturnUrlKey, ReturnUrl);

            mockedView.Raise(x => x.OnLogin += null, mockedView.Object, mockedArgs.Object);

            mockedAuthFactory.Verify(f => f.CreateApplicationSignInManager(mockedContext.Object), Times.Once());
            mockedUserManager.Verify(f => f.PasswordSignIn(Email, Password, IsPersistent), Times.Once());
            Assert.AreEqual(expectedUrl, mockedResponse.RedirectUrl);
        }
    }
}
