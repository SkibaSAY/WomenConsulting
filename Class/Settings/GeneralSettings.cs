using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WomenConsulting
{
    public class GeneralSettings
    {
        public string SurnameName { get; set; } = "Картошка маленькая";
        public string Address { get; set; } = "***";
        public string Age { get; set; } = "27";
        public DateTime LastMenstr { get; set; }
        public GeneralSettings() { }
        public GeneralSettings(string surname,string address,string age, DateTime lastMenstrDate)
        {
            SurnameName = surname;
            Address = address;
            Age = age;
            LastMenstr = lastMenstrDate;
        }

        //другие поля пока не нужны
    }
}
