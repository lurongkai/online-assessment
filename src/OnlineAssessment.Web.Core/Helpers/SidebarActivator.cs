using System.Web.Mvc;

namespace OnlineAssessment.Web.Core.Helpers
{
    public class SidebarActivator
    {
        public static object ActiveCheck(ViewContext viewContext, string controller, string action, string keyword) {
            var theController = viewContext.RouteData.Values["controller"].ToString().ToLower();
            var theAction = viewContext.RouteData.Values["action"].ToString().ToLower();

            if (
                theController == controller.ToLower() &&
                theAction == action.ToLower()
                ) {
                var rawUrl = viewContext.RequestContext.HttpContext.Request.RawUrl.ToLower();
                if (rawUrl.Contains(keyword.ToLower())) {
                    return MvcHtmlString.Create("item-actived");
                }
            }
            return MvcHtmlString.Create("");
        }
    }
}