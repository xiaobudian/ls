using ls.web.service.Int;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ls.web.Controllers
{
    public class TestController : ApiController
    {
        public IBlogService blogService { get; set; }
        
        [HttpGet]
        public string Index()
        {
            blogService.TestTransactionScope();
            return "success";
        }

    }
}
