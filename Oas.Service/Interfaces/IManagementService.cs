﻿using System;
using System.Collections.Generic;
using Oas.Domain;
using Oas.Domain.Application;

namespace Oas.Service.Interfaces
{
    public interface IManagementService
    {
        IEnumerable<News> GetTopNews(int count);
        News GetNews(Guid newsId);

        Guid CreateNews(News news);
        void ModifyNews(Guid newsId, News news);
        void DeleteNews(Guid newsId);

        void CreateTeacher(Teacher teacher);
        void CreateStudent(Student student);

        void SubscribeCourse(Guid studentId, string courseId);
        void AssigningCourse(Guid teacherId, string courseId);
    }
}