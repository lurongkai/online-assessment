// Author:
//      Lu Rongkai <lurongkai@gmail.com>
// 
// Copyright (c) 2014 lurongkai
// 
// This program is free software; you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation; either version 2 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
// 
// Source code hosted on: https://github.com/lurongkai/online-assessment

using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineAssessment.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            var defaultNamespaces = new string[]
            {
                "OnlineAssessment.Web.Core.Controllers"
            };

            #region Teacher Url

            routes.MapRoute("Question", "{subjectKey}/Question/{action}/{questionId}",
                new {controller = "Question", action = "List", questionId = UrlParameter.Optional}, defaultNamespaces
                );
            routes.MapRoute("ExaminationPaper", "{subjectKey}/Paper/{action}/{paperId}",
                new {controller = "Paper", action = "List", paperId = UrlParameter.Optional}, defaultNamespaces
                );
            routes.MapRoute("ExaminationManage", "{subjectKey}/ExamManage/{action}/{examinationId}",
                new {controller = "ExaminationManage", examinationId = "List"}, defaultNamespaces
                );
            routes.MapRoute("Evaluating", "{subjectKey}/Eval/{examinationPaperId}/{action}",
                new {controller = "Evaluating", action = "List"}, defaultNamespaces
                );

            #endregion

            #region Student Url

            routes.MapRoute("Testing", "{subjectKey}/Test/{questionCategory}/{action}/{testingDate}",
                new {controller = "Testing", action = "Begin", testingDate = UrlParameter.Optional}, defaultNamespaces
                );
            routes.MapRoute("Examination", "{subjectKey}/Exam/{action}/{examinationId}",
                new {controller = "Examination", action = "List", examinationId = UrlParameter.Optional}, defaultNamespaces
                );

            #endregion

            routes.MapRoute("Admin", "Admin/{action}",
                new {controller = "Admin", action = "Index"}, defaultNamespaces
                );

            routes.MapRoute("Dashboard", "{subjectKey}/Dashboard",
                new {controller = "Home", action = "Dashboard"}, defaultNamespaces
                );

            routes.MapRoute("Default", "{controller}/{action}/{id}",
                new {controller = "Home", action = "Index", id = UrlParameter.Optional}, defaultNamespaces
                );
        }
    }
}