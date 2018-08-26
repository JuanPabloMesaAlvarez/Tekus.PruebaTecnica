using System.Web.Http;
using Tekus.Application.Utils;
using Tekus.Infraestructure.Dependencies;
using Unity.WebApi;

namespace Tekus.WebAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            RegisterTypes.RegisterApplicationTypes();
            var container = DependencyFactory.Container;

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}