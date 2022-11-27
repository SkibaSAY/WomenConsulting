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

        //временно
        public string Name { get; set; } = "Плод";

        public Fetus(string path,string name)
        {
            this.Name = name;
            string inputDir = "";
            if (Directory.Exists(path))
            {
                CurrentDirectory = new DirectoryInfo(path);
                inputDir = path;
            }

            trimestr1 = new Trimestr(Path.Combine(inputDir, Sample.FirstTrimestrName), Sample.FirstTrimestrFullName, new Trimestr1());
            trimestr2 = new Trimestr(Path.Combine(inputDir, Sample.SecondTrimestrName), Sample.SecondTrimestrFullName, new Trimestr2());
            trimestr3 = new Trimestr(Path.Combine(inputDir, Sample.ThirdTrimestrName), Sample.ThirdTrimestrFullName, new Trimestr3());
        }
    }
}
