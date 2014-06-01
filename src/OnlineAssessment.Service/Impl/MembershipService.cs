using System;
using System.Collections.Generic;
using OnlineAssessment.Domain;
using OnlineAssessment.Infrastructure;

namespace OnlineAssessment.Service
{
    public class MembershipService : IMembershipService
    {
        public ApplicationUser GetProfile(string userId) {
            using (var context = new OnlineAssessmentContext()) {
                ApplicationUser user = context.Users.Find(userId);

                return user;
            }
        }

        public IEnumerable<Subject> GetStudentSubjects(string studentId) {
            using (var context = new OnlineAssessmentContext())
            {
                var student = context.Students.Find(studentId);
                return student.LearningSubjects;
            }
        }

        public Subject GetTeacherSubject(string teacherId) {
            using (var context = new OnlineAssessmentContext()) {
                var teacher = context.Teachers.Find(teacherId);
                return teacher.ResponsibleSubject;
            }
        }
    }
}