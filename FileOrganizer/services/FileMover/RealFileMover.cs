using FileOrganizer.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOrganizer.services.FileMover
{
    public class RealFileMover : IFileMover
    {
        private readonly Logger _logger;
        private readonly List<FileMoveRecord> _moveHistory = new List<FileMoveRecord>();


        public RealFileMover(Logger logger)
        {
            _logger = logger;
        }

        public void MoveFile(string filePath, string targetFolder)
        {
            Directory.CreateDirectory(targetFolder);

            string fileName = Path.GetFileName(filePath);
            string destPath = Path.Combine(targetFolder, fileName);

            File.Move(filePath, destPath, true);
            _moveHistory.Add(new FileMoveRecord
            {
                OriginalPath = filePath,
                NewPath = destPath
            });
            _logger.LogRealMove(filePath,destPath);
        }
        public void UndoAll()
        {
            foreach (var record in _moveHistory.AsEnumerable().Reverse())
            {
                if (File.Exists(record.NewPath))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(record.OriginalPath)!);
                    File.Move(record.NewPath, record.OriginalPath);

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"[UNDO] {Path.GetFileName(record.NewPath)} restored.");
                    Console.ResetColor();
                }
            }
            _moveHistory.Clear();
        }
    }


}

