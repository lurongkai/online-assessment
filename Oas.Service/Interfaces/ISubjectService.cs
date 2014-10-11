using System.Collections.Generic;

namespace Oas.Service.Interfaces
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