using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WomenConsulting
{
    public static class Sample
    {
        public static string Directory { get; } = @"..\..\Шаблоны";
        public static string FirstTrimestrName { get; } = "1_trimestr.docx";
        public static string FirstTrimestrFullName = Path.Combine(Sample.Directory, Sample.FirstTrimestrName);

        public static string SecondTrimestrName { get; } = "2_trimestr.docx";
        public static string SecondTrimestrFullName = Path.Combine(Sample.Directory, Sample.SecondTrimestrName);

        public static string ThirdTrimestrName { get; } = "3_trimestr.docx";
        public static string ThirdTrimestrFullName = Path.Combine(Sample.Directory, Sample.ThirdTrimestrName);

        public static string MalyeSrokiName { get; } = "MalyeSroki.docx";
        public static string MalyeSrokiFullName = Path.Combine(Sample.Directory, Sample.MalyeSrokiName);

        static Sample()
        {

        }
    }
}
