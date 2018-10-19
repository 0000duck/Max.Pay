using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
namespace Max.Web.Presentation.Infrastructure
{
    public static class Utils
    {
        public static string FmtCert(this string cert)
        {
            if (!string.IsNullOrEmpty(cert) && cert.Length > 10)
            {
                Regex regx = new Regex(@"(?<=\w{6}).+(?=\w{4})", RegexOptions.IgnoreCase);
                cert = regx.Replace(cert, "********");
            }

            return cert;
        }
    }
}