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

            routes.MapRoute("Question", "{subjectId}/Question/{action}/{questionId}",
                new { controller = "Question", action = "List", questionId = UrlParameter.Optional }, defaultNamespaces
                );
            routes.MapRoute("ExaminationPaper", "{subjectId}/Paper/{action}/{paperId}",
                new { controller = "Paper", action = "List", paperId = UrlParameter.Optional }, defaultNamespaces
                );
            routes.MapRoute("ExaminationManage", "{subjectId}/ExamManage/{action}/{examinationId}",
                new { controller = "ExaminationManage", examinationId = "List" }, defaultNamespaces
                );
            routes.MapRoute("Evaluating", "{subjectId}/Eval/{examinationPaperId}/{action}",
                new { controller = "Evaluating", action = "List" }, defaultNamespaces
                );

            #endregion

            #region Student Url

            routes.MapRoute("Testing", "{subjectId}/Test/{questionCategory}/{action}/{testingDate}",
                new { controller = "Testing", action = "Begin", testingDate = UrlParameter.Optional }, defaultNamespaces
                );
            routes.MapRoute("Examination", "{subjectId}/Exam/{action}/{examinationId}",
                new { controller = "Examination", action = "List", examinationId = UrlParameter.Optional }, defaultNamespaces
                );

            #endregion

            routes.MapRoute("Admin", "Admin/{action}",
                new { controller = "Admin", action = "Index" }, defaultNamespaces
                );

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }, defaultNamespaces
                );
        }
    }
}