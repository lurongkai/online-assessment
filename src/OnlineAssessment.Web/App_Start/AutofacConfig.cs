using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using OnlineAssessment.Web.Core.Controllers;
using OnlineAssessment.Web.Core.Integration;

namespace OnlineAssessment.Web
{
    public class AutofacConfig
    {
        public static void RegisterIoc() {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof (AutofacConfig).Assembly);
            builder.RegisterControllers(typeof (HomeController).Assembly);

            builder.RegisterModule<AutofacModule>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}