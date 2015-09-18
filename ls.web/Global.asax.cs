using ls.core;
using ls.web.core;
using ls.web.service;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace ls.web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
                        
            Initialize();
        }

        public static void Initialize()
        {
            DtoMappers.RegisterDtoMapper();

            IFrameworkInitializer initializer = new FrameworkInitializer()
            {
                MvcIocInitializer = new AutofacMvcIocInitializer(),
                WebApiIocInitializer = new AutofacWebApiIocInitializer()
            };
            initializer.Initialize();
        }
    }
}
