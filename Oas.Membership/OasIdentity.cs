using Microsoft.AspNet.Identity.EntityFramework;

namespace Oas.Membership
{
    public class OasIdentity : IdentityUser
    {
        public Gender Gender { get; set; }
    }
}