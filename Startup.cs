using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(bp2.Startup))]
namespace bp2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
