using Microsoft.AspNet.Identity;

namespace Oas.Membership
{
    public abstract class OasRoleManager : RoleManager<OasIdentityRole>
    {
        public OasRoleManager(OasRoleStore store) : base(store) {}
    }
}