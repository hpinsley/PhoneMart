using System.Configuration;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Angular.Nag.Data;
using System.Data.Entity;


namespace Angular.Nag.Services {
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class WebApiApplication : System.Web.HttpApplication {
        protected void Application_Start() {

            Bootstrapper.Initialise();

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            if (ConfigurationManager.AppSettings["InitDb"].ToLower() == "yes") {
                System.Diagnostics.Trace.WriteLine("Initializing database");
                Database.SetInitializer(new PhoneDatabaseInitializer());
                System.Diagnostics.Trace.WriteLine("Database Initialized");
            }
        }
    }
}