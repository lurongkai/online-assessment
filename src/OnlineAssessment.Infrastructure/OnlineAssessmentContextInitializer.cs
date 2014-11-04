using System;
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
            if (userManager.Create(admin, @"admin").Succeeded) { userManager.AddToRole(admin.Id, "Admin"); }
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

            if (userManager.Create(student, @"student").Succeeded) { userManager.AddToRole(student.Id, "Student"); }
            if (userManager.Create(teacher, @"teacher").Succeeded) { userManager.AddToRole(teacher.Id, "Teacher"); }

            #endregion

            #region Create Question Fake Data

            var r = new Random();

            for (var i = 1; i <= 5000; i++) {
                var question = new Question() {
                    QuestionBody = Guid.NewGuid().ToString(),
                    QuestionModule = QuestionModule.Theory
                };
                //试题难度系数取0.3到1之间的随机值
                question.QuestionDegree = r.Next(30, 100)*0.01;

                //单选题2分
                if (i <= 2000) {
                    question.QuestionForm = QuestionForm.SingleSelection;
                    question.Score = 2;
                    question.QuestionOptions.Add(new QuestionOption() {
                        Description = Guid.NewGuid().ToString(),
                        IsRightAnswer = true
                    });
                    for (var optionIndex = 0; optionIndex < r.Next(3, 6); optionIndex++) {
                        question.QuestionOptions.Add(new QuestionOption() {
                            Description = Guid.NewGuid().ToString(),
                            IsRightAnswer = false
                        });
                    }
                }

                //多选题3分
                if (i > 2000 && i <= 4000) {
                    question.QuestionForm = QuestionForm.MultipleSelection;
                    question.Score = 3;
                    question.QuestionOptions.Add(new QuestionOption() {
                        Description = Guid.NewGuid().ToString(),
                        IsRightAnswer = true
                    });
                    for (var optionIndex = 0; optionIndex < r.Next(3, 6); optionIndex++) {
                        question.QuestionOptions.Add(new QuestionOption() {
                            Description = Guid.NewGuid().ToString(),
                            IsRightAnswer = r.Next(0, 10) < 3
                        });
                    }
                }

                //问答题分数为难度系数*10
                if (i > 4000 && i <= 5000) {
                    question.QuestionForm = QuestionForm.Subjective;
                    question.Score = question.QuestionDegree > 0.3
                        ? (int) Math.Floor(question.QuestionDegree*10)
                        : 3;
                    question.ReferenceRightAnswer = Guid.NewGuid().ToString();
                }

                subject1.Questions.Add(question);
            }

            #endregion

            #region News

            for (var i = 0; i < 10; i++) {
                context.News.Add(new News() {
                    Title = Guid.NewGuid().ToString(),
                    Content = Guid.NewGuid().ToString(),
                    PublishedDate = DateTime.Now.AddDays(new Random().Next(1, 100))
                });
            }

            #endregion

            context.SaveChanges();
        }
    }
}