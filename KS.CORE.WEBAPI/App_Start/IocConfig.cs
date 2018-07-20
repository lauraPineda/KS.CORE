using Autofac;
using Autofac.Integration.WebApi;
using KS.CORE.DATAMANAGER;
using System.Reflection;
using System.Web.Http;

namespace KS.CORE.WEBAPI
{
    public class IocConfig
    {
        public static void Configure()
        {

            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            //builder.RegisterType < EntityFrameworkProductRepository> ().AsImplementedInterfaces().InstancePerApiRequest().InstancePerHttpRequest();

            builder.RegisterType<CotizacionRequest>().AsImplementedInterfaces().InstancePerApiRequest();
            builder.RegisterType<OrdenRequest>().AsImplementedInterfaces().InstancePerApiRequest();



            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}