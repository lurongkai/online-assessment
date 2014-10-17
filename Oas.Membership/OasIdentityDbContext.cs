using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Oas.Membership
{
    public class OasIdentityDbContext : IdentityDbContext<OasIdentityUser>
    {
        public OasIdentityDbContext() : base("Oas.Membership") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            Database.SetInitializer(new OasIdentityInitializer());
            base.OnModelCreating(modelBuilder);
        }
    }
}