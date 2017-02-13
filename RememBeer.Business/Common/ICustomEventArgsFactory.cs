using RememBeer.Business.Account.Confirm.Contracts;
using RememBeer.Business.Account.ForgotPassword.Contracts;
using RememBeer.Business.Account.Login.Contracts;
using RememBeer.Business.Account.ManagePassword.Contracts;
using RememBeer.Business.Account.Register.Contracts;
using RememBeer.Business.Admin.Brewery.Contracts;
using RememBeer.Business.Common.EventArgs.Contracts;
using RememBeer.Business.Reviews.My.Contracts;
using RememBeer.Models.Contracts;

namespace RememBeer.Business.Common
{
    public interface ICustomEventArgsFactory
    {
        IConfirmEventArgs CreateConfirmEventArgs(string userId, string code);

        IForgotPasswordEventArgs CreateForgottenPasswordEventArgs(string email);

        ILoginEventArgs CreateLoginEventArgs(string email, string password, bool rememberMe);

        IChangePasswordEventArgs CreateChangePasswordEventArgs(string currentPassword,
                                                               string newPassword,
                                                               string userId);

        IRegisterEventArgs CreateRegisterEventArg(string userName, string email, string password);

        IBeerReviewInfoEventArgs CreateBeerReviewInfoEventArgs(IBeerReview beerReview);

        IBeerReviewInfoEventArgs CreateBeerReviewInfoEventArgs(IBeerReview beerReview, byte[] image);

        IIdentifiableEventArgs<T> CreateIdentifiableEventArgs<T>(T id);

        ISearchEventArgs CreateSearchEventArgs(string pattern);

        IBreweryUpdateEventArgs CreateBreweryUpdateEventArgs(int id, string description, string name, string country);
    }
}
