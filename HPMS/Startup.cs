using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HPMS.Startup))]
namespace HPMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
