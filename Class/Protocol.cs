using Aspose.Words;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WomenConsulting.Class;

namespace WomenConsulting
{
    public class Protocol
    {
        public List<Fetus> fetuses { get; set; }
        public GeneralSettings generalSettings { get; set; }

        public Protocol(string currentDirectory)
        {
            fetuses = new List<Fetus>();
            InitFetuses(currentDirectory);
            generalSettings = new GeneralSettings();
        }
        private void InitFetuses(string currentDirectory)
        {
            //существование и создание по шаблону учти в конструкторах триместров(см. далее)
            var firstStrimPath = Path.Combine(currentDirectory, Sample.FirstTrimestrName);

            if(!File.Exists(firstStrimPath))
                firstStrimPath = Path.Combine(Sample.Directory, Sample.FirstTrimestrName);

            var firstTrimDoc = new Document(Path.);


            fetuses.Add(new Fetus(currentDirectory, "Плод 1"));
            fetuses.Add(new Fetus(currentDirectory, "Плод 2"));
        }
        public void Save(string CurrentDirectory)
        {
            //временно
            //переписать после обсуждения логики сохранения

            var fetus = fetuses.First();
            fetus.trimestr1.SaveTrimestr(CurrentDirectory);
            fetus.trimestr2.SaveTrimestr(CurrentDirectory);
            fetus.trimestr3.SaveTrimestr(CurrentDirectory);
        }

    }
}
