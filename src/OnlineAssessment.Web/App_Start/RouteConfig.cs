using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineAssessment.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            var defaultNamespaces = new string[] {
                "OnlineAssessment.Web.Core.Controllers"
            };

            #region Teacher Url

            routes.MapRoute("Question", "{subjectKey}/Question/{action}/{questionId}",
                new { controller = "Question", action = "List", questionId = UrlParameter.Optional }, defaultNamespaces
                );
            routes.MapRoute("ExaminationPaper", "{subjectKey}/Paper/{action}/{paperId}",
                new { controller = "Paper", action = "List", paperId = UrlParameter.Optional }, defaultNamespaces
                );
            routes.MapRoute("ExaminationManage", "{subjectKey}/ExamManage/{action}/{examinationId}",
                new { controller = "ExaminationManage", examinationId = "List" }, defaultNamespaces
                );
            routes.MapRoute("Evaluating", "{subjectKey}/Eval/{examinationPaperId}/{action}",
                new { controller = "Evaluating", action = "List" }, defaultNamespaces
                );

            #endregion

            #region Student Url

            routes.MapRoute("Testing", "{subjectKey}/Test/{questionCategory}/{action}/{testingDate}",
                new { controller = "Testing", action = "Begin", testingDate = UrlParameter.Optional }, defaultNamespaces
                );
            routes.MapRoute("Examination", "{subjectKey}/Exam/{action}/{examinationId}",
                new { controller = "Examination", action = "List", examinationId = UrlParameter.Optional }, defaultNamespaces
                );

            #endregion

            routes.MapRoute("Admin", "Admin/{action}",
                new { controller = "Admin", action = "Index" }, defaultNamespaces
                );

            routes.MapRoute("Dashboard", "{subjectKey}/Dashboard",
                new { controller = "Home", action = "Dashboard" }, defaultNamespaces
                );

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }, defaultNamespaces
                );
        }
    }
}