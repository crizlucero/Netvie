using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NetvieWeb.Startup))]
namespace NetvieWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
