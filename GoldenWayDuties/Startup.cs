using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GoldenWayDuties.Startup))]
namespace GoldenWayDuties
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
