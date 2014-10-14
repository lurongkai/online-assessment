using Autofac;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Oas.Membership;

namespace Oas.Integration
{
    public class MembershipModule : Module
    {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<OasIdentityDbContext>().InstancePerRequest();
            
            builder.RegisterType<OasUserStore>().As<IUserStore<OasIdentityUser>>().InstancePerRequest();
            builder.RegisterType<OasRoleStore>().As<IRoleStore<IdentityRole, string>>().InstancePerRequest();

            builder.RegisterType<OasUserManager>().InstancePerRequest();
            builder.RegisterType<OasRoleManager>().InstancePerRequest();
        }
    }
}