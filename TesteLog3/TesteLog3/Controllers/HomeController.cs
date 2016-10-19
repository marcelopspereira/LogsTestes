using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Serilog;

namespace TesteLog3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var logger = new LoggerConfiguration()
        .WriteTo.MSSqlServer(@"Server=(localdb)\ProjectsV12;Database=LogEvents;
        	Trusted_Connection=True;", "Logs")
        .CreateLogger();

            logger.Information("I am an information log");
            logger.Error("Hello, I am an error log");
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}