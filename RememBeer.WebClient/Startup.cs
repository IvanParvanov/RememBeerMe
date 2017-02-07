using System.Web.Http;
using System.Web.Routing;

using Microsoft.Owin;

using Ninject;
using Ninject.Web;
using Ninject.Web.WebApi;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;

using Owin;

using RememBeer.WebClient.App_Start;

using WebFormsMvp.Binder;

[assembly: OwinStartupAttribute(typeof(RememBeer.WebClient.Startup))]

namespace RememBeer.WebClient
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var kernel = NinjectWebCommon.CreateKernel();
            PresenterBinder.Factory = kernel.Get<IPresenterFactory>();

            this.ConfigureAuth(app, kernel);

            //var webApiConfiguration = new HttpConfiguration();
            //webApiConfiguration.Routes.MapHttpRoute(
            //    name: "DefaultApi",
            //    routeTemplate: "{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional, controller = "values" });

            //app.UseNinjectWebApi(webApiConfiguration);
        }
    }
}
