using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace Oas
{
    public class AutofacConfig
    {
        public static void RegisterIoc() {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof (OasApplication).Assembly);
            builder.RegisterAssemblyModules(typeof (OasApplication).Assembly);
            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}