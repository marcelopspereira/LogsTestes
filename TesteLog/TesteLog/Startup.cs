using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TesteLog.Startup))]
namespace TesteLog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
