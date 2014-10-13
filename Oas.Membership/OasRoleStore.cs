using Microsoft.AspNet.Identity.EntityFramework;

namespace Oas.Membership
{
    public class OasRoleStore : RoleStore<OasIdentityRole>
    {
        public OasRoleStore(OasIdentityDbContext context) : base(context) {}
    }
}