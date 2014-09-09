using System;
using System.Collections.Generic;
using OnlineAssessment.Domain;

namespace OnlineAssessment.Service
{
    public interface IManagementService
    {
        ApplicationUser GetProfile(string userId);

        IEnumerable<Subject> GetStudentSubjects(string studentId);
        Subject GetTeacherSubject(string teacherId);

        IEnumerable<News> GetAllNews(int? page, int pageSize = 50);
        Guid CreateNews(News news);
        void DeleteNews(Guid newsId);
        News GetNews(Guid newsId);
        void EditNews(News modifiedNews);
    }
}