using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CCAPL.UI.Startup))]
namespace CCAPL.UI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
