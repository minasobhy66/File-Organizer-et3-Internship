using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOrganizer.models
{
    public class FileMoveRecord
    {
        public string OriginalPath { get; set; }
        public string NewPath { get; set; }
    }
}
