using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Oas.Membership
{
    public class OasIdentityInitializer : DropCreateDatabaseIfModelChanges<OasIdentityDbContext>
    {
        protected override void Seed(OasIdentityDbContext context) {
            var roleManager = new OasRoleManager(new RoleStore<IdentityRole>(context));
            var userManager = new OasUserManager(new UserStore<OasIdentityUser>(context));

            roleManager.Create(new IdentityRole("Admin"));
            roleManager.Create(new IdentityRole("Teacher"));
            roleManager.Create(new IdentityRole("Student"));

            var passwordValidatorBackup = userManager.PasswordValidator;
            userManager.PasswordValidator = new MinimumLengthValidator(5);
            var admin = new OasIdentityUser("admin");
            userManager.Create(admin, "admin");
            userManager.AddToRole(admin.Id, "Admin");
            userManager.PasswordValidator = passwordValidatorBackup;
            


            context.SaveChanges();
        }
    }
}
