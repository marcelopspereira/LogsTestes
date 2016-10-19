using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TesteLog3.Startup))]
namespace TesteLog3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
