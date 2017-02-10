using System;
using System.Web.UI;
using System.Web.UI.WebControls;

using Ninject;

using RememBeer.Data.Repositories.Contracts;

namespace RememBeer.WebClient
{
    public partial class _Default : Page
    {
        [Inject]
        public IUserData UserRepo { private get; set; }

        [Inject]
        public IBreweriesData BrewRepo { private get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void UserDataSource_OnContextCreating(object sender, LinqDataSourceContextEventArgs e)
        {
            e.ObjectInstance = this.UserRepo;
        }
    }
}
