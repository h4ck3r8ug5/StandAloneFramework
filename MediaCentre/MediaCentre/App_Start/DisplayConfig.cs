using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.WebPages;

namespace MediaCentre.App_Start
{
    public class DisplayConfig
    {
        public static void RegisterDisplayModes(IList<IDisplayMode> displayModes)
        {
            var modeDesktop = new DefaultDisplayMode("")
            {
                ContextCondition = (c => c.Request.IsDesktop())
            };
            var modeSmartphone = new DefaultDisplayMode("smart")
            {
                ContextCondition = (c => c.Request.IsSmartPhone())
            };
            var modeTablet = new DefaultDisplayMode("tablet")
            {
                ContextCondition = (c => c.Request.IsTablet())
            };
            displayModes.Clear();
            displayModes.Add(modeSmartphone);
            displayModes.Add(modeTablet);
            displayModes.Add(modeDesktop);
        }
    }

    public static class HttpRequestExtensions
    {
        public static bool IsDesktop(this HttpRequestBase request)
        {
            return true;
        }

        public static bool IsSmartPhone(this HttpRequestBase request)
        {
            return true;
        }

        public static bool IsTablet(this HttpRequestBase request)
        {
            return IsTabletInternal(request.UserAgent);
        }

        private static bool IsTabletInternal(string userAgent)
        {
            var ua = userAgent.ToLower();
            return ua.Contains("ipad") || ua.Contains("gt-");
        }
    }
}