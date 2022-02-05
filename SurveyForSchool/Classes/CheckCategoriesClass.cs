using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyForSchool
{
    class CheckCategoriesClass
    {
        public List<string> LoadingCategories(string line)
        {
            List<string> categories = new List<string>();
            List<string> dirInfos = Directory.GetDirectories(line).ToList();

            foreach (var item in dirInfos)
            {
                string[] category = item.Split('\\');
                categories.Add(category.Last());
            }
            return categories;
        }
    }
}
