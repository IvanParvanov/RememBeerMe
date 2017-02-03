using System;

using RememBeer.Business.Account.Auth;

using WebFormsMvp;

namespace RememBeer.Business.Account.Common
{
    public class AuthenticationPresenter<TView> : Presenter<TView> where TView : class, IView
    {
        public AuthenticationPresenter(IAuthFactory authFactory, TView view) 
            : base(view)
        {
            if (authFactory == null)
            {
                throw new ArgumentNullException(nameof(authFactory));
            }

            this.AuthFactory = authFactory;
        }

        protected IAuthFactory AuthFactory { get; }
    }
}
