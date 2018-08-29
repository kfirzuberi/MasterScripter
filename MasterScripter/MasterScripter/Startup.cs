using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MasterScripter.Startup))]
namespace MasterScripter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
