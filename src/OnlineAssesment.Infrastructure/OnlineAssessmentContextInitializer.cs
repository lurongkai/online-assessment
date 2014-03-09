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
            var admin = new SystemUser() {
                Name = "Admin",
                UserName = "admin"
            };
            userManager.PasswordValidator = new MinimumLengthValidator(5);
            if (userManager.Create(admin, @"admin").Succeeded) {
                userManager.AddToRole(admin.Id, "Admin");
            }
            userManager.PasswordValidator = new MinimumLengthValidator(6);

            var subject = new Subject()
            {
                Name = "Test Subject"
            };
            context.Subjects.Add(subject);

            var student = new Student() { 
                Name = "Test Student",
                UserName = "student"
            };
            var teacher = new Teacher() { 
                Name = "Test Teacher",
                UserName = "teacher",
                ResponsibleSubject = subject
            };
            student.LearningSubjects.Add(subject);

            if (userManager.Create(student, @"student").Succeeded) {
                userManager.AddToRole(student.Id, "Student");
            }
            if (userManager.Create(teacher, @"teacher").Succeeded) {
                userManager.AddToRole(teacher.Id, "Teacher");
            }

        }
    }
}
