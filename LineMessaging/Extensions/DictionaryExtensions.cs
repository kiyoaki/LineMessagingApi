using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace LineMessaging
{
    internal static class DictionaryExtensions
    {
        internal static string ToQueryString(this Dictionary<string, object> source)
        {
            if (source == null) throw new ArgumentNullException();
            if (source.Count == 0) return string.Empty;
            return "?" + string.Join("&", source.Select(x => $"{WebUtility.UrlEncode(x.Key)}={WebUtility.UrlEncode(x.Value?.ToString())}"));
        }
    }
}
