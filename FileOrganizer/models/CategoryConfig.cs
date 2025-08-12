using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOrganizer.models
{
    public class CategoryConfig
    {

        public Dictionary<string, List<string>> categories { get; set; } = new();

       public string GetCategoryByExtension(string extension)
        {
            extension = extension.ToLower();
            var category = categories
                                  .FirstOrDefault(c => c.Value.Contains(extension))
                                  .Key;

            return string.IsNullOrEmpty(category) ? "Others" : category;
        }

    }


}

