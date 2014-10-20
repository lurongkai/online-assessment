using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Oas.Domain.Repository;
using Oas.Infrastructure.Repository;

namespace Oas.Integration
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<CourseRepository>().As<ICourseRepository>().InstancePerRequest();
            builder.RegisterType<NewsRepository>().As<INewsRepository>().InstancePerRequest();
            builder.RegisterType<QuestionService>().As<IQuestionService>().InstancePerRequest();
        }
    }
}