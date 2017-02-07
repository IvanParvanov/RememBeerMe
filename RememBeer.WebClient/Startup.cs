using System.Web.Http;
using System.Web.Routing;

using Microsoft.Owin;

using Ninject;

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

            RouteTable.Routes.MapHttpRoute(
                                           name: "DefaultApi",
                                           routeTemplate: "api/{controller}/{id}",
                                           defaults: new { id = System.Web.Http.RouteParameter.Optional }
                );
            GlobalConfiguration.Configuration.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
        }
    }
}
