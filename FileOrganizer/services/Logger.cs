using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOrganizer.services
{

    public class Logger
    {
    
        public void LogSimulateMove(string filePath, string destPath)
        {
            Log(filePath, destPath, "[SIMULATE]");
        }

        public void LogRealMove(string filePath, string destPath)
        {
            Log(filePath, destPath, "[MOVE]");
        }
        private void Log(string filePath, string destPath, string status)
        {
            var time = DateTime.Now.ToString("HH:mm:ss");

            Console.WriteLine($"{time} - {status.PadRight(10)} {Path.GetFileName(filePath)}");

            Console.WriteLine($"       From: {filePath}\n       To:   {destPath}");
        }

    }
}


