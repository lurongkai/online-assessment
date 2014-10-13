using System.Web.Mvc;
using System.Web.Routing;

namespace Oas
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region Teacher Url

            routes.MapRoute("Question", "{subjectKey}/Question/{action}/{questionId}",
                new {controller = "Question", action = "List", questionId = UrlParameter.Optional}
                );
            routes.MapRoute("ExaminationPaper", "{subjectKey}/Paper/{action}/{paperId}",
                new {controller = "Paper", action = "List", paperId = UrlParameter.Optional}
                );
            routes.MapRoute("ExaminationManage", "{subjectKey}/ExamManage/{action}/{examinationId}",
                new {controller = "ExaminationManage", examinationId = "List"}
                );
            routes.MapRoute("Evaluating", "{subjectKey}/Eval/{examinationPaperId}/{action}",
                new {controller = "Evaluating", action = "List"}
                );

            #endregion

            #region Student Url

            routes.MapRoute("Testing", "{subjectKey}/Test/{questionCategory}/{action}/{testingDate}",
                new {controller = "Testing", action = "Begin", testingDate = UrlParameter.Optional}
                );
            routes.MapRoute("Examination", "{subjectKey}/Exam/{action}/{examinationId}",
                new {controller = "Examination", action = "List", examinationId = UrlParameter.Optional}
                );

            #endregion

            routes.MapRoute("Admin", "Admin/{action}",
                new {controller = "Admin", action = "Index"}
                );

            routes.MapRoute("Dashboard", "{subjectKey}/Dashboard",
                new {controller = "Home", action = "Dashboard"}
                );

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}