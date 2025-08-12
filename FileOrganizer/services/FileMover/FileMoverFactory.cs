using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOrganizer.services.FileMover
{
    public static class FileMoverFactory
    {
        public static IFileMover Create(bool simulate, Logger logger)
        {
            return simulate ? new SimulatedFileMover(logger) : new RealFileMover(logger);
        }
    }

}
