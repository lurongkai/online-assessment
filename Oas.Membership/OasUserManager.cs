using Microsoft.AspNet.Identity;

namespace Oas.Membership
{
    public class OasUserManager : UserManager<OasIdentityUser>
    {
        public OasUserManager(IUserStore<OasIdentityUser> store) : base(store) {}
    }
}