using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineAssessment.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapRoute("Question", "{subjectId}/Question/{action}/{questionType}",
                new {controller = "Question", action = "Index", questionType = UrlParameter.Optional}
                );

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}