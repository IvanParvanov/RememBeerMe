using Ninject;

using RememBeer.Data;

using WebFormsMvp.Web;

namespace RememBeer.WebClient.BasePages
{
    public class IdentityHelperPage<TModel> : MvpPage<TModel> where TModel : class, new()
    {
        [Inject]
        public IIdentityHelper IdentityHelper { protected get; set; }
    }
}