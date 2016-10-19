using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TesteLog2.Startup))]
namespace TesteLog2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
