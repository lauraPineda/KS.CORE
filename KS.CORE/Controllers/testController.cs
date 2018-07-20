using KS.CORE.ENTITIES;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace KS.CORE.WEBAPI.Controllers
{
    public class testController : ApiController
    {
        [HttpGet]
        public int GetLogin()
        {
            
            return 1;
        }

    }
}
