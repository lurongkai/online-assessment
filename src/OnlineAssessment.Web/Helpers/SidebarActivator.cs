using System.Web.Mvc;

namespace OnlineAssessment.Web.Helpers
{
    public class SidebarActivator
    {
        public static object ActiveCheck(ViewContext ViewContext, string controller, string action, string keyword) {
            var theController = ViewContext.RouteData.Values["controller"].ToString().ToLower();
            var theAction = ViewContext.RouteData.Values["action"].ToString().ToLower();

            if (
                theController == controller.ToLower() &&
                theAction == action.ToLower()
                ) {
                var rawUrl = ViewContext.RequestContext.HttpContext.Request.RawUrl.ToLower();
                if (rawUrl.Contains(keyword.ToLower())) {
                    return MvcHtmlString.Create("item-actived");
                }
            }
            return MvcHtmlString.Create("");
        }
    }
}