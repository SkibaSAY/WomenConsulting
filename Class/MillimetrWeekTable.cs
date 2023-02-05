using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WomenConsulting
{
    public class WeekAndDay
    {
        public int weeks;
        public int days;

        public WeekAndDay(int weeks = 0, int days = 0)
        {
            this.weeks = weeks;
            this.days = days;
        }
    }

    public class MillimetrWeekTable
    {
        public Dictionary<int, WeekAndDay> lengthMatkaTable;
        public Dictionary<int, WeekAndDay> widthMatkaTable;
        public Dictionary<int, WeekAndDay> PZRMatkaTable;
        Dictionary<int, WeekAndDay> sizeRMatkaTable;

        public Dictionary<int, WeekAndDay> KTRTable;
        public Dictionary<int, WeekAndDay> EggTable;

        public MillimetrWeekTable()
        {
            Init();
        }

        public void Init()
        {

        }

        private WeekAndDay GetMinWeekAndDay(Dictionary<int, WeekAndDay> dict, int value)
        {
            var correspondingWeekAndDay = new WeekAndDay();
            var difference = 1000;

            var listOfSize = dict.ToList();
            for (int i = 0; i < dict.Count; i++)
            {
                var currentDifference = Math.Abs(listOfSize[i].Key - value);
                if (currentDifference < difference)
                {
                    difference = currentDifference;
                    correspondingWeekAndDay = listOfSize[i].Value;
                }
            }
            return correspondingWeekAndDay;
        }

        public WeekAndDay GetWeekFromValue(int value, string typeOfTable)
        {
            var correspondingWeekAndDay = new WeekAndDay();
            switch (typeOfTable)
            {
                case "Matka":
                    correspondingWeekAndDay = GetMinWeekAndDay(sizeRMatkaTable, value);
                    break;
                case "KTR":
                    if(KTRTable.First().Key > value || KTRTable.Last().Key < value)
                    {
                        return new WeekAndDay();
                    }
                    correspondingWeekAndDay = KTRTable[value];
                    break;
                case "Egg":
                    correspondingWeekAndDay = GetMinWeekAndDay(EggTable, value);
                    break;
            }
            return correspondingWeekAndDay;
        }
    }
}
