using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CallCenterManagementSystem.Startup))]
namespace CallCenterManagementSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
