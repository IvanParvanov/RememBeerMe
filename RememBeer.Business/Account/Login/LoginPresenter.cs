using System;

using RememBeer.Business.Account.Auth;
using RememBeer.Business.Account.Common;
using RememBeer.Business.Account.Login.Contracts;

namespace RememBeer.Business.Account.Login
{
    public class LoginPresenter : AuthenticationPresenter<ILoginView>
    {
        public LoginPresenter(IAuthFactory factory, ILoginView view) 
            : base(factory, view)
        {
            this.View.OnLogin += this.ViewOnOnLogin;
        }

        private void ViewOnOnLogin(object sender, ILoginEventArgs loginEventArgs)
        {
            throw new NotImplementedException();
        }
    }
}
