using Infra.Interfaces;
using Infra.Repositorios;
using Microsoft.Practices.Unity;
using System.Web.Http;

namespace API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var container = new UnityContainer();
            container.RegisterType<IUsuarioRepositorio, UsuarioRepositorio>(new HierarchicalLifetimeManager());
            config.DependencyResolver = new UnityResolver(container);

            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
