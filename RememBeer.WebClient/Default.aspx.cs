using System;
using System.Linq;
using System.Web.UI;

using Ninject;

using RememBeer.Data.Repositories.Contracts;

namespace RememBeer.WebClient
{
    public partial class _Default : Page
    {
        [Inject]
        public IUserData UserRepo { private get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            var users = this.UserRepo.Users.All.ToList();
        }
    }
}