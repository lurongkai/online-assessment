﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Oas
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.LowercaseUrls = true;

            routes.MapRoute("course-question",
                "course/{courseId}/question/{action}/{questionId}",
                new {controller = "Question", action = "Index", questionId = UrlParameter.Optional});
            routes.MapRoute("course-subject",
                "course/{courseId}/subject/{action}/{subjectId}",
                new {controller = "Subject", action = "Index", subjectId = UrlParameter.Optional});
            routes.MapRoute("course-exercise",
                "course/{courseId}/exercise/{subjectId}/{action}",
                new {controller = "Exercise", action = "Index", subjectId = UrlParameter.Optional});
            routes.MapRoute("course-exam",
                "course/{courseId}/exam/{action}/",
                new {controller = "Exam", action = "Index"});
            routes.MapRoute("course-record",
                "course/{courseId}/record/{action}/",
                new { controller = "Record", action = "Index" });
            routes.MapRoute("course-eval",
                "course/{courseId}/eval/{action}/",
                new { controller = "Eval", action = "Index" });
            routes.MapRoute("course",
                "course/{courseId}/{action}",
                new {controller = "Course", action = "Index", questionId = UrlParameter.Optional});

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional}
                );
        }
    }
}