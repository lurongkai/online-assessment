using System;
using System.Collections.Generic;
using Oas.Domain;
using Oas.Domain.Application;
using Oas.Service.Messages;

namespace Oas.Service.Interfaces
{
    public interface IManagementService
    {
        IEnumerable<News> GetAllNews(PaginationData paginationData);
        News GetNews(Guid newsId);

        Guid CreateNews(News news);
        void ModifyNews(Guid newsId, News modifiedNews);
        void DeleteNews(Guid newsId);

        void CreateTeacher(Guid courseId, Teacher teacher);
        void CreateStudent(Student student);

        void SubscribeCourse(Guid courseId, Guid studentId);
    }
}