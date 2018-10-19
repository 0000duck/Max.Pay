using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Max.Web.Management
{
    public class ZipHelper_Project
    {
        public static void Extract(string zipPath, string extractPath)
        {
            using (ZipArchive archive = ZipFile.OpenRead(zipPath))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    entry.ExtractToFile(Path.Combine(extractPath, entry.FullName));
                }
            }
        }

        public static void Create(string startPath, string zipPath)
        {
            ZipFile.CreateFromDirectory(startPath, zipPath);
        }
    }
}
