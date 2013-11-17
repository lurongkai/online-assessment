using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnlineAssesment.Web.Startup))]
namespace OnlineAssesment.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
