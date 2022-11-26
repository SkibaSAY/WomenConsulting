using System;
using System.Collections.Generic;
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
            generalSettings = new GeneralSettings();
            InitTest(currentDirectory);
        }
        private void InitTest(string currentDirectory)
        {
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
