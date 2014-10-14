using Microsoft.AspNet.Identity.EntityFramework;

namespace Oas.Membership
{
    public class OasRoleStore : RoleStore<IdentityRole>
    {
        public OasRoleStore(OasIdentityDbContext context) : base(context) { }
    }
}
