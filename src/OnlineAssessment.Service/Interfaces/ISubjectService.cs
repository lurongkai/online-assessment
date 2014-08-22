using System;
using System.Collections.Generic;
using OnlineAssessment.Domain;

namespace OnlineAssessment.Service
{
    public interface ISubjectService
    {
        IEnumerable<Subject> GetAllSubjects();
        string AddSubject(Subject subject);
        Subject GetSubject(string subjectKey);
        void DeleteSubject(string subjectKey);
        string EditSubject(Subject editedSubject);
    }
}