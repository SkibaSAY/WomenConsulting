using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WomenConsulting
{
    public class WeekValues
    {
        [DisplayName(displayName:"Номер недели")]
        public int WeekNumber { get; set; }

        [DisplayName(displayName: "Минимальная масса")]
        public int MinMass { get; set; }

        [DisplayName(displayName: "Максимальная масса")]
        public int MaxMass { get; set; }

        public int MinBPR { get; set; }
        public int MaxBPR { get; set; }
        public int MinDB { get; set; }
        public int MaxDB { get; set; }
        public int MinOZh { get; set; }
        public int MaxOZh { get; set; }
        public int MinDGK { get; set; }
        public int MaxDGK { get; set; }
        public WeekValues()
        {

        }
        public WeekValues(int number, int Minmass, int Maxmass, int Minbpr, int Maxbpr, int Mindb, int Maxdb, int Minozh, int Maxozh, int Mindgk, int Maxdgk)
        {
            WeekNumber = number;
            MinMass = Minmass;
            MaxMass = Maxmass;
            MinBPR = Minbpr;
            MaxBPR = Maxbpr;
            MinDB = Mindb;
            MaxDB = Maxdb;
            MinOZh = Minozh;
            MaxOZh = Maxozh;
            MinDGK = Mindgk;
            MaxDGK = Maxdgk;
        }
        public override string ToString()
        {
            var stringList = typeof(WeekValues).GetProperties().Select(x => $"{x.Name} : {x.GetValue(this)}").ToList();

            return String.Join(" ", stringList);
        }
    }
}
