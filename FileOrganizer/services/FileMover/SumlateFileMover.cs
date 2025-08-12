using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOrganizer.services.FileMover
{

    public class SimulatedFileMover : IFileMover
    {
        private readonly Logger _logger;

        public SimulatedFileMover(Logger logger)
        {
            _logger = logger;
        }

        public void MoveFile(string filePath, string targetFolder)
        {
            Directory.CreateDirectory(targetFolder);

            string fileName = Path.GetFileName(filePath);
            string destPath = Path.Combine(targetFolder, fileName);

            _logger.LogSimulateMove(filePath,destPath);
        }
    }

}

