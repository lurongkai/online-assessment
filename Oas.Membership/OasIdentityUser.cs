using Microsoft.AspNet.Identity.EntityFramework;

namespace Oas.Membership
{
    public class OasIdentityUser : IdentityUser
    {
        public OasIdentityUser() : base() { }
        public OasIdentityUser(string userName) : base(userName) { }

        public Gender Gender { get; set; }
    }
}