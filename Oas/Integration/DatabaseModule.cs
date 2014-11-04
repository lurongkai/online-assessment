using Autofac;
using Oas.Infrastructure;
using Oas.Membership;

namespace Oas.Integration
{
    public class DatabaseModule : Module
    {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<OasContext>().InstancePerRequest();
            builder.RegisterType<OasIdentityDbContext>().InstancePerRequest();
        }
    }
}