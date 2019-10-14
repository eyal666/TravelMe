using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TravelMe.Startup))]
namespace TravelMe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
