﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WomenConsulting
{
    public class GeneralSettings
    {
        public string surnameName { get; set; } = "Картошка маленькая";
        public string address { get; set; } = "***";
        public string age { get; set; } = "27";
        public DateTime dateOfLastMen { get; set; }
        public GeneralSettings() { }
        public GeneralSettings(string surname,string address,string age, DateTime dateOfLastMen)
        {
            surnameName = surname;
            this.address = address;
            this.age = age;
            this.dateOfLastMen = dateOfLastMen;
        }

        public Dictionary<string,string> GetFields()
        {
            var result = new Dictionary<string, string>();
            foreach(var prop in typeof(GeneralSettings).GetProperties())
            {
                result.Add(prop.Name, prop.GetValue(this).ToString());
            }
            return result;
        }
        //другие поля пока не нужны
    }
}
