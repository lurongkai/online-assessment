using Microsoft.AspNet.Identity.EntityFramework;

namespace Oas.Membership
{
    public class OasIdentityDbContext : IdentityDbContext<OasIdentityUser>
    {
        public OasIdentityDbContext() : base("Oas.Membership") { }
    }
}