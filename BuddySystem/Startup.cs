using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BuddySystem.Startup))]
namespace BuddySystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
