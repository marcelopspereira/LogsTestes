using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Serilog;
using Serilog.Formatting.Json;
using Serilog.Sinks.RollingFile;

namespace TesteLog2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.LiterateConsole()
                //.MinimumLevel.Debug()
                //.WriteTo.RollingFile(@"c:\TesteLog2\Log-{Date}.txt",
                //outputTemplate:
                //"{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} {Level}:{EventId} [{SourceContext}] {Message}{NewLine}{Exception}")
                               .WriteTo.Sink(new
                    RollingFileSink(@"c:\TesteLog2\Log-{Date}.txt",
                        new JsonFormatter(renderMessage: true), 1073741824, 31))
                .WriteTo.RollingFile(@"c:\TesteLog2\Log-{Date}.txt")
                .MinimumLevel.Verbose()
                .CreateLogger();

            Log.Logger.Information("Application Started");

            for (int i = 0; i < 10; i++)
            {
                Log.Logger.Information("Iteration {I}", i);
            }

            Log.Logger.Information("Existing Application");

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