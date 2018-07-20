using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
