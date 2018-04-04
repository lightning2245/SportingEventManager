using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SportingEventManager.Startup))]
namespace SportingEventManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
