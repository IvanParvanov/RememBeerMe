using Microsoft.AspNet.Identity;

using Moq;

using NUnit.Framework;

using Ploeh.AutoFixture;

using RememBeer.Business.Logic.Account.Register;
using RememBeer.Business.Logic.Account.Register.Contracts;
using RememBeer.Business.Services.Contracts;
using RememBeer.Common.Identity.Contracts;
using RememBeer.Tests.Common;
using RememBeer.Tests.Common.MockedClasses;

namespace RememBeer.Tests.Business.Logic.Account.Register.Presenter
{
    public class OnRegister_Should : TestClassBase
    {

        [Test]
        public void CallUserServiceRegisterUserMethod_WithCorrectParameters()
        {
            var expectedEmail = this.Fixture.Create<string>();
            var expectedPassword = this.Fixture.Create<string>();
            var expectedName = this.Fixture.Create<string>();

            var view = new Mock<IRegisterView>();
            var args = new Mock<IRegisterEventArgs>();
            var identityHelper = new Mock<IIdentityHelper>();

            args.Setup(a => a.Email).Returns(expectedEmail);
            args.Setup(a => a.Password).Returns(expectedPassword);
            args.Setup(a => a.UserName).Returns(expectedName);

            var userService = new Mock<IUserService>();
            userService.Setup(s => s.RegisterUser(expectedName, expectedEmail, expectedPassword))
                       .Returns(IdentityResult.Failed(new string[1]));

            var httpResponse = new MockedHttpResponse();
            var presenter = new RegisterPresenter(userService.Object, identityHelper.Object, view.Object)
            {
                HttpContext = new MockedHttpContextBase(httpResponse)
            };

            view.Raise(v => v.OnRegister += null, view.Object, args.Object);

            userService.Verify(s => s.RegisterUser(expectedName, expectedEmail, expectedPassword), Times.Once());
        }

        [Test]
        public void SetViewErrors_WhenRegisterFails()
        {
            var expectedEmail = this.Fixture.Create<string>();
            var expectedPassword = this.Fixture.Create<string>();
            var expectedName = this.Fixture.Create<string>();
            var expectedMessage = this.Fixture.Create<string>();

            var view = new Mock<IRegisterView>();
            var args = new Mock<IRegisterEventArgs>();
            var identityHelper = new Mock<IIdentityHelper>();

            args.Setup(a => a.Email).Returns(expectedEmail);
            args.Setup(a => a.Password).Returns(expectedPassword);
            args.Setup(a => a.UserName).Returns(expectedName);

            var userService = new Mock<IUserService>();
            userService.Setup(s => s.RegisterUser(expectedName, expectedEmail, expectedPassword))
                       .Returns(IdentityResult.Failed(new [] { expectedMessage }));

            var httpResponse = new MockedHttpResponse();
            var presenter = new RegisterPresenter(userService.Object, identityHelper.Object, view.Object)
            {
                HttpContext = new MockedHttpContextBase(httpResponse)
            };

            view.Raise(v => v.OnRegister += null, view.Object, args.Object);

            view.VerifySet(v => v.ErrorMessageText = expectedMessage, Times.Once());
        }

        [Test]
        public void CallGetReturnUrl_WhenRegisterSucceeds()
        {
            var expectedEmail = this.Fixture.Create<string>();
            var expectedPassword = this.Fixture.Create<string>();
            var expectedName = this.Fixture.Create<string>();
            var returnUrl = this.Fixture.Create<string>();
            const string returnUrlKey = "ReturnUrl";

            var view = new Mock<IRegisterView>();
            var args = new Mock<IRegisterEventArgs>();
            args.Setup(a => a.Email).Returns(expectedEmail);
            args.Setup(a => a.Password).Returns(expectedPassword);
            args.Setup(a => a.UserName).Returns(expectedName);

            var userService = new Mock<IUserService>();
            userService.Setup(s => s.RegisterUser(expectedName, expectedEmail, expectedPassword))
                       .Returns(IdentityResult.Success);

            var identityHelper = new Mock<IIdentityHelper>();
            identityHelper.Setup(i => i.GetReturnUrl(returnUrl))
                .Returns(returnUrl);

            var httpResponse = new MockedHttpResponse();
            var presenter = new RegisterPresenter(userService.Object, identityHelper.Object, view.Object)
            {
                HttpContext = new MockedHttpContextBase(httpResponse)
            };
            presenter.HttpContext.Request.QueryString.Add(returnUrlKey, returnUrl);

            view.Raise(v => v.OnRegister += null, view.Object, args.Object);

            identityHelper.Verify(i => i.GetReturnUrl(returnUrl), Times.Once());
        }

        [Test]
        public void RedirectToCorrectPage_WhenRegisterSucceeds()
        {
            var expectedEmail = this.Fixture.Create<string>();
            var expectedPassword = this.Fixture.Create<string>();
            var expectedName = this.Fixture.Create<string>();
            var query = this.Fixture.Create<string>();
            var returnUrl = this.Fixture.Create<string>();
            const string returnUrlKey = "ReturnUrl";

            var view = new Mock<IRegisterView>();
            var args = new Mock<IRegisterEventArgs>();
            args.Setup(a => a.Email).Returns(expectedEmail);
            args.Setup(a => a.Password).Returns(expectedPassword);
            args.Setup(a => a.UserName).Returns(expectedName);

            var userService = new Mock<IUserService>();
            userService.Setup(s => s.RegisterUser(expectedName, expectedEmail, expectedPassword))
                       .Returns(IdentityResult.Success);

            var identityHelper = new Mock<IIdentityHelper>();
            identityHelper.Setup(i => i.GetReturnUrl(query))
                .Returns(returnUrl);

            var httpResponse = new MockedHttpResponse();
            var presenter = new RegisterPresenter(userService.Object, identityHelper.Object, view.Object)
            {
                HttpContext = new MockedHttpContextBase(httpResponse)
            };
            presenter.HttpContext.Request.QueryString.Add(returnUrlKey, query);

            view.Raise(v => v.OnRegister += null, view.Object, args.Object);

            Assert.AreEqual(returnUrl, httpResponse.RedirectUrl);
        }
    }
}
