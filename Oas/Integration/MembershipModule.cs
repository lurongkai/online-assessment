using Autofac;
using Microsoft.AspNet.Identity;
using Oas.Membership;

namespace Oas.Integration
{
    public class MembershipModule : Module
    {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<OasIdentityDbContext>().InstancePerRequest();
            builder.RegisterType<OasUserStore>().As<IUserStore<OasIdentity>>().InstancePerRequest();
            builder.RegisterType<OasRoleStore>().As<IRoleStore<OasIdentityRole>>().InstancePerDependency();

            builder.RegisterType<OasUserManager>().InstancePerRequest();
            builder.RegisterType<OasRoleManager>().InstancePerRequest();
        }
    }
}