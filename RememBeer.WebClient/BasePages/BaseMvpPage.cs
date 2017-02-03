using Ninject;

using RememBeer.Business.Account;
using RememBeer.Data.Identity.Contracts;

using WebFormsMvp.Web;

namespace RememBeer.WebClient.BasePages
{
    public class BaseMvpPage<TModel> : MvpPage<TModel> where TModel : class, new()
    {
        [Inject]
        public IIdentityHelper IdentityHelper { protected get; set; }

        [Inject]
        public ICustomEventArgsFactory EventArgsFactory { protected get; set; }
    }
}