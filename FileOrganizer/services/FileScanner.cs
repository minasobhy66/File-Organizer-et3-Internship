using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOrganizer.services
{
    public class FileScanner
    {
        public IEnumerable<string> GetFiles(string folderPath)
        {
            if (!Directory.Exists(folderPath))
                throw new DirectoryNotFoundException($"Folder not found: {folderPath}");

            return Directory.GetFiles(folderPath);
        }
    }
}
