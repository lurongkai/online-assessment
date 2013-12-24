using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineAssesment.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace OnlineAssesment.Infrastructure
{
    public class OnlineAssessmentContextInitializer : DropCreateDatabaseIfModelChanges<OnlineAssessmentContext>
    {
        protected override void Seed(OnlineAssessmentContext context) {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<SystemUser>(new UserStore<SystemUser>(context));

            // add pre-defined roles.
            roleManager.Create(new IdentityRole("Admin"));
            roleManager.Create(new IdentityRole("Teacher"));
            roleManager.Create(new IdentityRole("Student"));

            // add admin.
            userManager.Create(new SystemUser() {
                Name = "Admin",
                UserName = "admin"
            }, @"admin");
        }
    }
}
