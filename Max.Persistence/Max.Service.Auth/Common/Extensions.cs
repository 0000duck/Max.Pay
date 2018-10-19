using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.Service.Auth
{
    public static class Extensions
    {
        public static string ToFormatUrl(this string url)
        {
            if (string.IsNullOrEmpty(url))
                return null;

            if (!url.StartsWith("/") && url != "/" && url != "#")
                url = "/" + url;

            if (url != "/")
                url = url.TrimEnd('/');

            return url.ToLower();
        }
    }
}
