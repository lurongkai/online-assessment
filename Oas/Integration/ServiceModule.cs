using Autofac;

namespace Oas.Integration
{
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder) {
            //builder.RegisterType<AnsweringService>().As<IAnsweringService>().InstancePerRequest();
            //builder.RegisterType<ExaminationService>().As<IExamService>().InstancePerRequest();
            //builder.RegisterType<ManagementService>().As<IManagementService>().InstancePerRequest();
            //builder.RegisterType<QuestionService>().As<IQuestionService>().InstancePerRequest();
            //builder.RegisterType<SubjectService>().As<ICourseService>().InstancePerRequest();
        }
    }
}