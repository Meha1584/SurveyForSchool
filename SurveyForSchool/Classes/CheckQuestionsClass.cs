using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyForSchool
{
    class CheckQuestionsClass
    {
        public List<Test> LoadingQuestions(int checkI, string line, string checkCategories)
        {
            List<Test> tests = new List<Test>();
            string pathCategoriesWithTest;
            if (checkI == 0)
            {
                pathCategoriesWithTest = line;
            }
            else
            {
                pathCategoriesWithTest = $@"{line}\{checkCategories}";
            }
            var fileInfo = Directory.GetFiles(pathCategoriesWithTest).ToList();
            foreach (var item in fileInfo)
            {
                string[] file = item.Split('\\');
                tests.Add(new Test(file.Last()));
            }

            return tests;
        }
    }
}
