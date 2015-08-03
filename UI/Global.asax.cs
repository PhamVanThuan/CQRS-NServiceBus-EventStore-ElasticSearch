using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using EasyNetQ;
using Messages.Events;
using UI.Handlers;

namespace UI
{
    public class MvcApplication : HttpApplication
    {
        public static IBus Bus = RabbitHutch.CreateBus("host=localhost;publisherConfirms=true");

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            Bus.Subscribe<ClientPossiblyStolen>("ClientPossiblyStolen", ClientPossiblyStolenHandler.Handle);
        }
    }
}
