using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineAssessment.Domain;

namespace OnlineAssessment.Infrastructure
{
    public class OnlineAssessmentContextInitializer : DropCreateDatabaseIfModelChanges<OnlineAssessmentContext>
    {
        protected override void Seed(OnlineAssessmentContext context) {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            // add pre-defined roles.
            roleManager.Create(new IdentityRole("Admin"));
            roleManager.Create(new IdentityRole("Teacher"));
            roleManager.Create(new IdentityRole("Student"));

            #region Add Admin
            var admin = new ApplicationUser {
                Name = "Admin",
                UserName = "admin"
            };
            var passwordValidatorBackup = userManager.PasswordValidator;
            userManager.PasswordValidator = new MinimumLengthValidator(5);
            if (userManager.Create(admin, @"admin").Succeeded) {
                userManager.AddToRole(admin.Id, "Admin");
            }
            userManager.PasswordValidator = passwordValidatorBackup;
            #endregion

            #region Add Subjects
            var subject1 = new Subject {
                SubjectKey = "CAI-L1",
                Name = "网络课件设计师一级"
            };
            var subject2 = new Subject {
                SubjectKey = "CAI-L2",
                Name = "网络课件设计师二级"
            };
            var subject3 = new Subject {
                SubjectKey = "CAI-L3",
                Name = "网络课件设计师三级"
            }; 
            context.Subjects.Add(subject1);
            context.Subjects.Add(subject2);
            context.Subjects.Add(subject3);
            #endregion

            #region Add test Student and Teacher
            var student = new Student {
                Name = "Test Student",
                UserName = "student"
            };
            var teacher = new Teacher {
                Name = "Test Teacher",
                UserName = "teacher",
                ResponsibleSubject = subject1
            };
            student.LearningSubjects.Add(subject1);
            student.LearningSubjects.Add(subject2);
            student.LearningSubjects.Add(subject3);

            if (userManager.Create(student, @"student").Succeeded) {
                userManager.AddToRole(student.Id, "Student");
            }
            if (userManager.Create(teacher, @"teacher").Succeeded) {
                userManager.AddToRole(teacher.Id, "Teacher");
            }
            #endregion
        }
    }
}