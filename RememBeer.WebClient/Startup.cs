using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RememBeer.WebClient.Startup))]
namespace RememBeer.WebClient
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            this.ConfigureAuth(app);
        }
    }
}
