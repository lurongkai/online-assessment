using Microsoft.Owin;
using OnlineAssessment.Web;
using Owin;

[assembly: OwinStartup(typeof (Startup))]

namespace OnlineAssessment.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}