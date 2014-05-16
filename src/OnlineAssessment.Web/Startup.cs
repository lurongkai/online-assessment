using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineAssessment.Web.Startup))]
namespace OnlineAssessment.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
