using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SurveyForSchool
{
    public class QuestionsClass
    {
        string titleQuestion;
        string pathImage;
        string otvetTrue;
        string otvet1;
        string otvet2;
        string otvet3;

        public string TitleQuestion { get => titleQuestion; set => titleQuestion = value; }
        public string PathImage { get => pathImage; set => pathImage = value; }
        public string OtvetTrue { get => otvetTrue; set => otvetTrue = value; }
        public string Otvet1 { get => otvet1; set => otvet1 = value; }
        public string Otvet2 { get => otvet2; set => otvet2 = value; }
        public string Otvet3 { get => otvet3; set => otvet3 = value; }
    }
}
