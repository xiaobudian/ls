using ls.service.Int;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ls.web.Controllers
{
    public class HomeController : Controller
    {
        public IBlogService blogService { get; set; }
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View(blogService.Blogs);
        }
    }
}
