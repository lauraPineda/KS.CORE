using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using KS.CORE.DATAMANAGER;

namespace KS.CORE.WEBAPI
{
    public class IocConfig
    {
        public static void Configure()
        {

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<CotizacionRequest>().AsImplementedInterfaces().InstancePerApiRequest();


            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}