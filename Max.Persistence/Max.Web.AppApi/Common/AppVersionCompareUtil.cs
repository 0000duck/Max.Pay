using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;

namespace Max.Web.AppApi.Common
{
    public class AppVersionCompareUtil
    {
        public static int? Compare(string appVersion, string appCompareVersion)
        {
            appVersion = Regex.Replace(appVersion, @"[^0-9.]", "").ToUpper();
            appCompareVersion = Regex.Replace(appCompareVersion, @"[^0-9.]", "").ToUpper();

            if (!Regex.IsMatch(appVersion, @"^[0-9]+(\.[0-9]+)*$") || !Regex.IsMatch(appCompareVersion, @"^[0-9]+(\.[0-9]+)*$"))
                return null;

            if (appVersion == appCompareVersion)
                return 0;

            string[] appVersionSplit = appVersion.Split('.');
            string[] appCompareVersionSplit = appCompareVersion.Split('.');
            int result = 0;

            for (int i = 0; i < appVersionSplit.Length; i++)
            {
                if (i >= appCompareVersionSplit.Length)
                {
                    return 1;
                }
                else
                {
                    result = Int32.Parse(appVersionSplit[i]) - Int32.Parse(appCompareVersionSplit[i]);

                    if (result > 0)
                        return 1;
                    else if (result < 0)
                        return -1;
                }
            }

            return -1;
        }
    }
}