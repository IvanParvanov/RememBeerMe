using System;

using RememBeer.Business.Account.Auth;

using WebFormsMvp;

namespace RememBeer.Business.Account.Common.Presenters
{
    public class AuthenticationPresenter<TView> : Presenter<TView> where TView : class, IView
    {
        public AuthenticationPresenter(IAuthProvider authProvider, TView view) 
            : base(view)
        {
            if (authProvider == null)
            {
                throw new ArgumentNullException(nameof(authProvider));
            }

            this.AuthProvider = authProvider;
        }

        protected IAuthProvider AuthProvider { get; }
    }
}
