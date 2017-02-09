using System;

using RememBeer.Business.Services.Contracts;

using WebFormsMvp;

namespace RememBeer.Business.Account.Common.Presenters
{
    public class UserServicePresenter<TView> : Presenter<TView> where TView : class, IView
    {
        public UserServicePresenter(IUserService userService, TView view) 
            : base(view)
        {
            if (userService == null)
            {
                throw new ArgumentNullException(nameof(userService));
            }

            this.UserService = userService;
        }

        protected IUserService UserService { get; }
    }
}
