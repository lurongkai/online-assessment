using Microsoft.AspNet.Identity;

namespace Oas.Membership
{
    public class OasUserManager : UserManager<OasIdentity>
    {
        public OasUserManager(OasUserStore store) : base(store) {}
    }
}