﻿using Microsoft.Owin;

using RememBeer.Business.Account.Common.EventArcs;
using RememBeer.Business.Account.Login.Contracts;

namespace RememBeer.Business.Account.Login
{
    public class LoginEventArgs:  ILoginEventArgs
    {
        public LoginEventArgs(string email, string password, bool rememberMe)
        {
            this.Email = email;
            this.Password = password;
            this.RememberMe = rememberMe;
        }

        public string Email { get; }

        public string Password { get; }

        public bool RememberMe { get; }
    }
}