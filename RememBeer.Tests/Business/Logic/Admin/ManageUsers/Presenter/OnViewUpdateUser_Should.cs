using Microsoft.AspNet.Identity;

using Moq;

using NUnit.Framework;

using Ploeh.AutoFixture;

using RememBeer.Business.Logic.Admin.ManageUsers;
using RememBeer.Business.Logic.Admin.ManageUsers.Contracts;
using RememBeer.Business.Services.Contracts;
using RememBeer.Tests.Common;

namespace RememBeer.Tests.Business.Logic.Admin.ManageUsers.Presenter
{
    [TestFixture]
    public class OnViewUpdateUser_Should : TestClassBase
    {
        [Test]
        public void Call_UserServiceUpdateUserMethodOnceWithCorrectParams()
        {
            var id = this.Fixture.Create<string>();
            var email = this.Fixture.Create<string>();
            var username = this.Fixture.Create<string>();
            var isConfirmed = this.Fixture.Create<bool>();

            var view = new Mock<IManageUsersView>();
            var userService = new Mock<IUserService>();
            userService.Setup(s => s.UpdateUser(id, email, username, isConfirmed))
                       .Returns(IdentityResult.Success);

            var args = new Mock<IUserUpdateEventArgs>();
            args.Setup(a => a.Id)
                .Returns(id);
            args.Setup(a => a.Email)
                .Returns(email);
            args.Setup(a => a.UserName)
                .Returns(username);
            args.Setup(a => a.IsConfirmed)
                .Returns(isConfirmed);

            var sut = new ManageUsersPresenter(userService.Object, view.Object);
            view.Raise(v => v.UserUpdate += null, view.Object, args.Object);

            userService.Verify(s => s.UpdateUser(id, email, username, isConfirmed), Times.Once);
        }

        [Test]
        public void Set_ViewSuccessMessage_WhenResultSucceeds()
        {
            var id = this.Fixture.Create<string>();
            var email = this.Fixture.Create<string>();
            var username = this.Fixture.Create<string>();
            var isConfirmed = this.Fixture.Create<bool>();

            var view = new Mock<IManageUsersView>();
            var userService = new Mock<IUserService>();
            userService.Setup(s => s.UpdateUser(id, email, username, isConfirmed))
                       .Returns(IdentityResult.Success);

            var args = new Mock<IUserUpdateEventArgs>();
            args.Setup(a => a.Id)
                .Returns(id);
            args.Setup(a => a.Email)
                .Returns(email);
            args.Setup(a => a.UserName)
                .Returns(username);
            args.Setup(a => a.IsConfirmed)
                .Returns(isConfirmed);
            var sut = new ManageUsersPresenter(userService.Object, view.Object);
            view.Raise(v => v.UserUpdate += null, view.Object, args.Object);

            view.VerifySet(v => v.SuccessMessageVisible = true);
            view.VerifySet(v => v.SuccessMessageText = It.IsAny<string>());
        }

        [Test]
        public void Set_ViewErrorMessage_WhenResultFails()
        {
            var id = this.Fixture.Create<string>();
            var email = this.Fixture.Create<string>();
            var username = this.Fixture.Create<string>();
            var isConfirmed = this.Fixture.Create<bool>();

            var view = new Mock<IManageUsersView>();
            var userService = new Mock<IUserService>();
            userService.Setup(s => s.UpdateUser(id, email, username, isConfirmed))
                       .Returns(IdentityResult.Failed());

            var args = new Mock<IUserUpdateEventArgs>();
            args.Setup(a => a.Id)
                .Returns(id);
            args.Setup(a => a.Email)
                .Returns(email);
            args.Setup(a => a.UserName)
                .Returns(username);
            args.Setup(a => a.IsConfirmed)
                .Returns(isConfirmed);

            var sut = new ManageUsersPresenter(userService.Object, view.Object);
            view.Raise(v => v.UserUpdate += null, view.Object, args.Object);

            view.VerifySet(v => v.ErrorMessageVisible = true);
            view.VerifySet(v => v.ErrorMessageText = It.IsAny<string>());
        }
    }
}
