using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OnlineAssessment.Domain;
using OnlineAssessment.Infrastructure;

namespace OnlineAssessment.Service
{
    public class SubjectService : ISubjectService
    {
        public IEnumerable<Subject> GetAllSubjects() {
            using (var context = new OnlineAssessmentContext()) {
                var subjects = context.Subjects;
                return subjects.ToList();
            }
        }

        public string AddSubject(Subject subject) {
            using (var context = new OnlineAssessmentContext()) {
                context.Subjects.Add(subject);
                context.SaveChanges();

                return subject.SubjectKey;
            }
        }

        public Subject GetSubject(string subjectKey) {
            using (var context = new OnlineAssessmentContext()) {
                var subject = context.Subjects.Find(subjectKey);
                
                return subject;
            }
        }

        public void DeleteSubject(string subjectKey) {
            using (var context = new OnlineAssessmentContext()) {
                var subject = context.Subjects.Find(subjectKey);
                context.Subjects.Remove(subject);
                context.SaveChanges();
            }
        }

        public string EditSubject(Subject editedSubject) {
            using (var context = new OnlineAssessmentContext()) {
                context.Subjects.Attach(editedSubject);
                context.Entry(editedSubject).State = EntityState.Modified;
                context.SaveChanges();

                return editedSubject.SubjectKey;
            }
        }
    }
}