using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.Web.Management
{
    public class SFTPConfig : ConfigurationSection
    {
        [ConfigurationProperty("HostName", IsRequired = true)]
        public string HostName
        {
            get { return (string)base["HostName"]; }
            set { base["HostName"] = value; }
        }
        [ConfigurationProperty("PortNumber", IsRequired = true)]
        public int PortNumber
        {
            get { return (int)base["PortNumber"]; }
            set { base["PortNumber"] = value; }
        }
        [ConfigurationProperty("UserName", IsRequired = true)]
        public string UserName
        {
            get { return (string)base["UserName"]; }
            set { base["UserName"] = value; }
        }
        [ConfigurationProperty("Password", IsRequired = true)]
        public string Password
        {
            get { return (string)base["Password"]; }
            set { base["Password"] = value; }
        }
        [ConfigurationProperty("RemoteDownloadPath", IsRequired = true)]
        public string RemoteDownloadPath
        {
            get { return (string)base["RemoteDownloadPath"]; }
            set { base["RemoteDownloadPath"] = value; }
        }
        [ConfigurationProperty("RemoteUploadPath", IsRequired = true)]
        public string RemoteUploadPath
        {
            get { return (string)base["RemoteUploadPath"]; }
            set { base["RemoteUploadPath"] = value; }
        }
        [ConfigurationProperty("LocalDownloadPath", IsRequired = true)]
        public string LocalDownloadPath
        {
            get { return (string)base["LocalDownloadPath"]; }
            set { base["LocalDownloadPath"] = value; }
        }

        [ConfigurationProperty("LocalUploadPath", IsRequired = true)]
        public string LocalUploadPath
        {
            get { return (string)base["LocalUploadPath"]; }
            set { base["LocalUploadPath"] = value; }
        }
    }
}
