using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Max.Web.Presentation.Helpers
{
    public static class StringExtensions
    {
        public static string HideLeft(this string value, int totalLen, int showLen, char hideChar = '*')
        {

            int count = totalLen - showLen;
            string newstring = "";
            for (int i = 0; i < count; i++)
            {
                newstring += hideChar;
            }
            newstring += value.Substring(totalLen - showLen, showLen);
            return newstring;
        }


        public static string HideMiddle(this string value, int totalLen, int leftStart, int showRightLen, char hideChar = '*')
        {

            int count = totalLen - leftStart - showRightLen;
            string newstring = "";
            newstring += value.Substring(0, leftStart);
            for (int i = 0; i < count; i++)
            {
                newstring += hideChar;
            }

            newstring += value.Substring(totalLen - showRightLen, showRightLen);
            return newstring;
        }
    }
}