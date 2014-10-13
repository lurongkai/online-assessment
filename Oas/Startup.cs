using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof (Oas.Startup))]

namespace Oas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}