using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Oas.Membership
{
    public class OasRoleManager : RoleManager<IdentityRole>
    {
        public OasRoleManager(IRoleStore<IdentityRole, string> store) : base(store) { }
    }
}