using System.Web.Http;
using Angular.Nag.Common.Implementations;
using Angular.Nag.Common.Interfaces;
using Angular.Nag.Data.Repositories;
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

            container.RegisterType<ISettings, Settings>();
            container.RegisterType<RepositoryFactories>();
            container.RegisterType<IRepositoryProvider, RepositoryProvider>();
            container.RegisterType<ICodeCamperUow, CodeCamperUow>();

            return container;
        }
    }
}