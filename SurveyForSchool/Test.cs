using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyForSchool
{
    public class Test
    {
        string nameTest;

        public Test(string nameTest)
        {
            NameTest = nameTest;
        }

        public string NameTest { get => nameTest; set => nameTest = value; }
    }
}
