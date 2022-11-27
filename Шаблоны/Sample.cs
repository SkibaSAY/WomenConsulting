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
        public static string FirstTrimestrName = "1_trimestr.docx";
        public static string FirstTrimestrFullName = Path.Combine(Sample.Directory, Sample.FirstTrimestrName);

        public static string SecondTrimestrName = "2_trimestr.docx";
        public static string SecondTrimestrFullName = Path.Combine(Sample.Directory, Sample.SecondTrimestrName);

        public static string ThirdTrimestrName = "3_trimestr.docx";
        public static string ThirdTrimestrFullName = Path.Combine(Sample.Directory, Sample.ThirdTrimestrName);

        public static string Directory = @"..\..\Шаблоны";
    }
}
