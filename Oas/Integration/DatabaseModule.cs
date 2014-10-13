using System.Data.Entity;
using Autofac;
using Oas.Infrastructure;

namespace Oas.Integration
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<OasContext>().As<DbContext>().InstancePerRequest();
        }
    }
}