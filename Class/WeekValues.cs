using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WomenConsulting.Class
{
    public class WeekValues
    {
        public int WeekNumber { get; set; }
        public int MinMass { get; set; }
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
    }
}
