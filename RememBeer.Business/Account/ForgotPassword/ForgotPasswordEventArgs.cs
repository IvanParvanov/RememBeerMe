using RememBeer.Business.Account.ForgotPassword.Contracts;

namespace RememBeer.Business.Account.ForgotPassword
{
    public class ForgotPasswordEventArgs : IForgotPasswordEventArgs
    {
        public ForgotPasswordEventArgs(string email)
        {
            this.Email = email;
        }

        public string Email { get; }
    }
}
