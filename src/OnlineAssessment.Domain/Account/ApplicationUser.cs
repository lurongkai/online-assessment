using Microsoft.AspNet.Identity.EntityFramework;

namespace OnlineAssessment.Domain
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
        public string Phone { get; set; }
        public Gender Gender { get; set; }
    }
}