using Microsoft.AspNet.Identity.EntityFramework;

namespace Oas.Membership
{
    public class OasUserStore : UserStore<OasIdentityUser>
    {
        public OasUserStore(OasIdentityDbContext context) : base(context) {}
    }
}