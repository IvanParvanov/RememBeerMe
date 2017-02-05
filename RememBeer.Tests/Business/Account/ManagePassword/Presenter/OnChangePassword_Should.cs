using System.Collections.Generic;
using System.Web;

using Microsoft.AspNet.Identity;
using Microsoft.Owin;

using Moq;

using NUnit.Framework;

using RememBeer.Business.Account.Auth;
using RememBeer.Business.Account.ManagePassword;
using RememBeer.Business.Account.ManagePassword.Contracts;
using RememBeer.Data.Identity.Contracts;
using RememBeer.Tests.Common.MockedClasses;

namespace RememBeer.Tests.Business.Account.ManagePassword.Presenter
{
    [TestFixture]
    public class OnChangePassword_Should
    {
        [Test]
        public void GetUserManagerFromFactory()
        {
            var view = new Mock<IManagePasswordView>();
            var ctx = new Mock<IOwinContext>();
            var manager = new Mock<IApplicationUserManager>();
            manager.Setup(m => m.ChangePassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                   .Returns(IdentityResult.Failed());

            var authFactory = new Mock<IAuthFactory>();
            authFactory.Setup(f => f.CreateApplicationUserManager(ctx.Object)).Returns(manager.Object);
            authFactory.Setup(f => f.GetOwinContext(It.IsAny<HttpContextBase>())).Returns(ctx.Object);
            var args = new Mock<IChangePasswordEventArgs>();

            var presenter = new ManagePasswordPresenter(authFactory.Object, view.Object);
            view.Raise(v => v.ChangePassword += null, view.Object, args.Object);

            authFactory.Verify(f => f.CreateApplicationUserManager(ctx.Object), Times.Once());
        }

        [Test]
        public void CallAddErrors_WhenResultHasFailed()
        {
            var view = new Mock<IManagePasswordView>();
            var ctx = new Mock<IOwinContext>();
            var manager = new Mock<IApplicationUserManager>();
            manager.Setup(m => m.ChangePassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                   .Returns(IdentityResult.Failed("error"));

            var authFactory = new Mock<IAuthFactory>();
            authFactory.Setup(f => f.CreateApplicationUserManager(ctx.Object)).Returns(manager.Object);
            authFactory.Setup(f => f.GetOwinContext(It.IsAny<HttpContextBase>())).Returns(ctx.Object);
            var args = new Mock<IChangePasswordEventArgs>();

            var presenter = new ManagePasswordPresenter(authFactory.Object, view.Object);
            view.Raise(v => v.ChangePassword += null, view.Object, args.Object);

            view.Verify(v => v.AddErrors(It.IsAny<IList<string>>()));
        }

        [Test]
        public void RedirectToCorrectUrl_WhenResultSucceeds()
        {
            var view = new Mock<IManagePasswordView>();
            var ctx = new Mock<IOwinContext>();
            var manager = new Mock<IApplicationUserManager>();
            manager.Setup(m => m.ChangePassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                   .Returns(IdentityResult.Success);
            var signInManager = new Mock<IApplicationSignInManager>();

            var authFactory = new Mock<IAuthFactory>();
            authFactory.Setup(f => f.CreateApplicationUserManager(ctx.Object)).Returns(manager.Object);
            authFactory.Setup(f => f.CreateApplicationSignInManager(ctx.Object)).Returns(signInManager.Object);
            authFactory.Setup(f => f.GetOwinContext(It.IsAny<HttpContextBase>())).Returns(ctx.Object);

            var args = new Mock<IChangePasswordEventArgs>();
            var httpResponse = new MockedHttpResponse();

            var presenter = new ManagePasswordPresenter(authFactory.Object, view.Object)
                            {
                                HttpContext = new MockedHttpContextBase(httpResponse)
                            };
            view.Raise(v => v.ChangePassword += null, view.Object, args.Object);

            Assert.AreEqual("~/Account/Manage?m=ChangePwdSuccess", httpResponse.RedirectUrl);
        }

        [Test]
        public void CallGetSignInManager_WhenResultSucceeds()
        {
            var view = new Mock<IManagePasswordView>();
            var ctx = new Mock<IOwinContext>();
            var manager = new Mock<IApplicationUserManager>();
            manager.Setup(m => m.ChangePassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                   .Returns(IdentityResult.Success);
            var signInManager = new Mock<IApplicationSignInManager>();

            var authFactory = new Mock<IAuthFactory>();
            authFactory.Setup(f => f.CreateApplicationUserManager(ctx.Object)).Returns(manager.Object);
            authFactory.Setup(f => f.CreateApplicationSignInManager(ctx.Object)).Returns(signInManager.Object);
            authFactory.Setup(f => f.GetOwinContext(It.IsAny<HttpContextBase>())).Returns(ctx.Object);
            var args = new Mock<IChangePasswordEventArgs>();
            var httpResponse = new MockedHttpResponse();

            var presenter = new ManagePasswordPresenter(authFactory.Object, view.Object)
            {
                HttpContext = new MockedHttpContextBase(httpResponse)
            };

            view.Raise(v => v.ChangePassword += null, view.Object, args.Object);

            authFactory.Verify(f => f.CreateApplicationSignInManager(ctx.Object), Times.Once());
        }

        [Test]
        public void SignIn_WhenResultSucceeds()
        {
            var view = new Mock<IManagePasswordView>();
            var ctx = new Mock<IOwinContext>();
            var manager = new Mock<IApplicationUserManager>();
            manager.Setup(m => m.ChangePassword(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()))
                   .Returns(IdentityResult.Success);
            var signInManager = new Mock<IApplicationSignInManager>();

            var authFactory = new Mock<IAuthFactory>();
            authFactory.Setup(f => f.CreateApplicationUserManager(ctx.Object)).Returns(manager.Object);
            authFactory.Setup(f => f.CreateApplicationSignInManager(ctx.Object)).Returns(signInManager.Object);
            authFactory.Setup(f => f.GetOwinContext(It.IsAny<HttpContextBase>())).Returns(ctx.Object);

            var args = new Mock<IChangePasswordEventArgs>();
            var httpResponse = new MockedHttpResponse();

            var presenter = new ManagePasswordPresenter(authFactory.Object, view.Object)
                            {
                                HttpContext = new MockedHttpContextBase(httpResponse)
                            };
            view.Raise(v => v.ChangePassword += null, view.Object, args.Object);

            signInManager.Verify(s => s.SignIn(null, false, false), Times.Once());
        }
    }
}
