using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WomenConsulting.Class
{
    /// <summary>
    /// плод
    /// </summary>
    public class Fetus
    {
        public DirectoryInfo CurrentDirectory;
        public Trimestr trimestr1 { get; set; }
        public Trimestr trimestr2 { get; set; }
        public Trimestr trimestr3 { get; set; }


        public Fetus(string path)
        {
            string inputFile = "";
            if (Directory.Exists(path))
            {
                CurrentDirectory = new DirectoryInfo(path);
                inputFile = path;
            }

            trimestr1 = new Trimestr(Path.Combine(inputFile, "1_trimestr.docx"), @"..\..\Шаблоны\1_trimestr.docx", new Trimestr1());
            trimestr2 = new Trimestr(Path.Combine(inputFile, "2_trimestr.docx"), @"..\..\Шаблоны\2_trimestr.docx", new Trimestr2());
            trimestr3 = new Trimestr(Path.Combine(inputFile, "3_trimestr.docx"), @"..\..\Шаблоны\3_trimestr.docx", new Trimestr3());
        }
    }
}
