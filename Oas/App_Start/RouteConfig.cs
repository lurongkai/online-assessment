using System.Web.Mvc;
using System.Web.Routing;

namespace Oas
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("course-question", 
                "course/{courseName}/question/{action}/{questionId}",
                new { controller = "Question", action = "Index", questionId = UrlParameter.Optional });
            routes.MapRoute("course-exercise",
                "course/{courseName}/exercise/{action}/{subjectId}",
                new { controller = "Exercise", action = "Index", subjectId = UrlParameter.Optional });
            routes.MapRoute("course-simulation",
                "course/{courseName}/simulation/{action}/",
                new { controller = "Simulation", action = "Index" });
            routes.MapRoute("course-subject",
                "course/{courseName}/subject/{action}/",
                new { controller = "Subject", action = "Index" });

            //routes.MapRoute("Question", "{subjectKey}/Question/{action}/{questionId}",
            //    new {controller = "Question", action = "List", questionId = UrlParameter.Optional}
            //    );
            //routes.MapRoute("ExaminationPaper", "{subjectKey}/Paper/{action}/{paperId}",
            //    new {controller = "Paper", action = "List", paperId = UrlParameter.Optional}
            //    );
            //routes.MapRoute("ExaminationManage", "{subjectKey}/ExamManage/{action}/{examinationId}",
            //    new {controller = "ExaminationManage", examinationId = "List"}
            //    );
            //routes.MapRoute("Evaluating", "{subjectKey}/Eval/{examinationPaperId}/{action}",
            //    new {controller = "Evaluating", action = "List"}
            //    );
            //routes.MapRoute("Testing", "{subjectKey}/Test/{questionCategory}/{action}/{testingDate}",
            //    new {controller = "Testing", action = "Begin", testingDate = UrlParameter.Optional}
            //    );
            //routes.MapRoute("Examination", "{subjectKey}/Exam/{action}/{examinationId}",
            //    new {controller = "Examination", action = "List", examinationId = UrlParameter.Optional}
            //    );
            routes.MapRoute("Admin", "admin/{action}",
                new {controller = "Admin", action = "Index"}
                );

            //routes.MapRoute("Dashboard", "{subjectKey}/Dashboard",
            //    new {controller = "Home", action = "Dashboard"}
            //    );

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}