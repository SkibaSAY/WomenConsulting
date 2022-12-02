using Aspose.Words;
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
        public Trimestr trimestr1 { get; set; }
        public Trimestr trimestr2 { get; set; }
        public Trimestr trimestr3 { get; set; }

        //временно
        public string Name { get; set; } = "Плод";

        public Fetus(string name, Document firstTrim, Document secondTrim, Document thirdTrim)
        {
            this.Name = name;

            trimestr1 = new Trimestr(firstTrim, new Trimestr1());
            trimestr2 = new Trimestr(secondTrim, new Trimestr2());
            trimestr3 = new Trimestr(thirdTrim, new Trimestr3());
        }
    }
}
