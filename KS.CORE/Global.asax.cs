using System.Web.Http;

namespace KS.CORE.WEBAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //IocConfig.Configure();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
