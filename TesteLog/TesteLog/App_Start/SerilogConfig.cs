using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Serilog;
using Serilog.Events;
using SerilogWeb.Classic.Enrichers;
using TesteLog.Models;

namespace TesteLog.App_Start
{
    public  class SerilogConfig
    {
        public static void Run()
        { 
            Log.Logger = new LoggerConfiguration()
                //.WriteTo.ColoredConsole() //Writes to console
                .WriteTo.Seq("http://localhost:5341") //Writes to Default Seq Server
                .WriteTo.RollingFile(@"C:\TesteLog\Log-{Date}.txt", restrictedToMinimumLevel: LogEventLevel.Warning)
                // Writes events above or equal to warning level to a file
                .Enrich.With(new UserNameEnricher()) //Enricher
                .Destructure.ByTransforming<Post>
                (p => new { Title = p.Title, Id = p.Id }) // Destructuring

                .CreateLogger();
        }
    }

    //public class UserNameEnricher
    //{
    //    public int Id { get; set; }
    //    public string Title { get; set; }
    //}
}