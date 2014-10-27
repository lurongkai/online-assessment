using System.Web.Mvc;
using System.Web.Routing;

namespace Oas
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute("course-question", 
                "course/{courseId}/question/{action}/{questionId}",
                new { controller = "Question", action = "Index", questionId = UrlParameter.Optional });
            routes.MapRoute("course-subject",
                "course/{courseId}/subject/{action}/{subjectId}",
                new { controller = "Subject", action = "Index", subjectId = UrlParameter.Optional });
            routes.MapRoute("course-exercise",
                "course/{courseId}/exercise/{action}/{subjectId}",
                new { controller = "Exercise", action = "Index", subjectId = UrlParameter.Optional });
            routes.MapRoute("course-simulation",
                "course/{courseId}/simulation/{action}/",
                new { controller = "Simulation", action = "Index" });
            routes.MapRoute("course",
                "course/{courseId}/{action}",
                new { controller = "Course", action = "Index", questionId = UrlParameter.Optional });

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}