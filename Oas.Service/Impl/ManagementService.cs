using Oas.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oas.Service.Impl
{
    public class ManagementService : IManagementService
    {
        public IEnumerable<Domain.Application.News> GetAllNews(Messages.PaginationData paginationData) {
            throw new NotImplementedException();
        }

        public Domain.Application.News GetNews(Guid newsId) {
            throw new NotImplementedException();
        }

        public Guid CreateNews(Domain.Application.News news) {
            throw new NotImplementedException();
        }

        public void ModifyNews(Guid newsId, Domain.Application.News news) {
            throw new NotImplementedException();
        }

        public void DeleteNews(Guid newsId) {
            throw new NotImplementedException();
        }

        public void CreateTeacher(Domain.Teacher teacher) {
            throw new NotImplementedException();
        }

        public void CreateStudent(Domain.Student student) {
            throw new NotImplementedException();
        }

        public void SubscribeCourse(Guid studentId, string courseId) {
            throw new NotImplementedException();
        }

        public void AssigningCourse(Guid teacherId, string courseId) {
            throw new NotImplementedException();
        }
    }
}
