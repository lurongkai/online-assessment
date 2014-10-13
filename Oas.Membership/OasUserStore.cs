using Microsoft.AspNet.Identity.EntityFramework;

namespace Oas.Membership
{
    public class OasUserStore : UserStore<OasIdentity>
    {
        public OasUserStore(OasIdentityDbContext context) : base(context) {}
    }
}