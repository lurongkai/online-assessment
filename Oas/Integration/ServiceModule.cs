using Autofac;
using Oas.Service.Impl;
using Oas.Service.Interfaces;

namespace Oas.Integration
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<CourseService>().As<ICourseService>().InstancePerRequest();
            builder.RegisterType<ExerciseService>().As<IExerciseService>().InstancePerRequest();
            builder.RegisterType<ManagementService>().As<IManagementService>().InstancePerRequest();
            builder.RegisterType<QuestionService>().As<IQuestionService>().InstancePerRequest();
            builder.RegisterType<ExamService>().As<IExamService>().InstancePerRequest();
        }
    }
}