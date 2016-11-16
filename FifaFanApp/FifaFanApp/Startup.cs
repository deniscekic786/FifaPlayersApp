using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FifaFanApp.Startup))]
namespace FifaFanApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
