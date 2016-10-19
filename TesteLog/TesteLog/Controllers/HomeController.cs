using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Serilog;

namespace TesteLog.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var postLog = Log.ForContext("PostId", 10);
            postLog.Information("Post {id} is deleted", 10);

            Log.Warning("Page under construction is accessed.");
            var postLog1 = Log.ForContext("PostId", 12);
            postLog1.Error("Error in viewing post {@Post}.", "testeett");

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