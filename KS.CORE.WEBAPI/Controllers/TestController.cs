using System.Web.Http;

namespace KS.CORE.WEBAPI.Controllers
{
    public class TestController : ApiController
    {
        [HttpGet]
        public int Get()
        {
            return 1;
        }
    }
}
