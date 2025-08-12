using FileOrganizer.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOrganizer.services
{
    public class FileCategorizer
    {

        private readonly CategoryConfig _config;

        public FileCategorizer(CategoryConfig config)
        {
            _config = config;
        }

        public string GetCategory(string fileName)
        {
            string ext = Path.GetExtension(fileName).ToLower();

            var category = _config.GetCategoryByExtension(ext);

            if (category!=null) return category;
            return "Others";
        }
    }
}

