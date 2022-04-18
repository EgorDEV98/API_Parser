using API.Service;
using Newtonsoft.Json.Linq;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Web;

namespace API.Utils
{
    class Utils
    {
        public static string GetRequest(string url)
        {
            WebClient wk = new WebClient();

            return wk.DownloadString(url);
        }

        public static string GetValueFromStringJSON(string json, string nameStr)
        {
            return JObject.Parse(json)[nameStr].ToString();
        }

        public static string toQueryString(NameValueCollection nvc)
        {
            var array = (
                from key in nvc.AllKeys
                from value in nvc.GetValues(key)
                select string.Format(
            "{0}={1}",
            HttpUtility.UrlEncode(key),
            HttpUtility.UrlEncode(value))
                ).ToArray();
            return "?" + string.Join("&", array);
        }

        public static string enumStatusToString(Status status)
        {
            switch ((int)status)
            {
                case 1: return "true";
                case 2: return "false";
                default: return "null";
            }
        }

        public static string enumRegionToString(RegionId regionId)
        {
            if ((int)regionId == 0)
                return "";
            return "&regionId=" + (int)regionId;
        }
    }
}
