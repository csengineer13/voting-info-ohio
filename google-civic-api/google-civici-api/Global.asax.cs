using System.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using google_civici_api.App_Start;
using google_civic_api.ViewModel.AutoMapper;
using google_civic_api.Domain.Common;

namespace google_civici_api
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;

            var webConfig = new WebConfigValues
            {
                ServerPath = Server.MapPath("/"),
                SiteRoot = ConfigurationManager.AppSettings["RootServerUrl"]
            };

            DIConfig.RegisterComponents(webConfig);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters); // We do this in DI
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ConfigMapper.MapAll(); // Kickstart AutoMapper; Declare Maps
        }
    }
}
