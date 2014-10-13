using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace Oas
{
    public class AutofacConfig
    {
        public static void RegisterIoc() {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(typeof (AutofacConfig).Assembly);

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}