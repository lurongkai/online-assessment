using OnlineAssessment.Domain;
using System.Collections.Generic;

namespace OnlineAssessment.Service
{
    public interface IMembershipService
    {
        ApplicationUser GetProfile(string userId);

        IEnumerable<Subject> GetStudentSubjects(string studentId);
        Subject GetTeacherSubject(string teacherId);
    }
}