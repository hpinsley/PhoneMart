using System.Web.Http;
using Angular.Nag.Data;
using Microsoft.Practices.Unity;

namespace Angular.Nag.Services
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // e.g. container.RegisterType<ITestService, TestService>();            

            container.RegisterType<IPhoneRepository, PhoneRepository>();
            return container;
        }
    }
}