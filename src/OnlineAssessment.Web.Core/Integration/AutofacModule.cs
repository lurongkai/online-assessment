using System.Data.Entity;
using Autofac;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineAssessment.Domain;
using OnlineAssessment.Infrastructure;
using OnlineAssessment.Service;

namespace OnlineAssessment.Web.Core.Integration
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder) {
            builder.RegisterType<AnsweringService>().As<IAnsweringService>().InstancePerRequest();
            builder.RegisterType<ExaminationService>().As<IExaminationService>().InstancePerRequest();
            builder.RegisterType<MembershipService>().As<IMembershipService>().InstancePerRequest();
            builder.RegisterType<QuestionService>().As<IQuestionService>().InstancePerRequest();
            builder.RegisterType<SubjectService>().As<ISubjectService>().InstancePerRequest();

            builder.RegisterType<OnlineAssessmentContext>().As<DbContext>().InstancePerRequest();
            builder.RegisterType<UserStore<ApplicationUser>>().As<IUserStore<ApplicationUser>>().InstancePerRequest();
            builder.RegisterType<UserManager<ApplicationUser>>().InstancePerRequest();
        }
    }
}