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
        public Dictionary<int, WeekAndDay> lengthMatkaTable = new Dictionary<int, WeekAndDay>();
        public Dictionary<int, WeekAndDay> widthMatkaTable = new Dictionary<int, WeekAndDay>();
        public Dictionary<int, WeekAndDay> PZRMatkaTable = new Dictionary<int, WeekAndDay>();
        Dictionary<int, WeekAndDay> sizeRMatkaTable = new Dictionary<int, WeekAndDay>();

        public Dictionary<int, WeekAndDay> KTRTable = new Dictionary<int, WeekAndDay>();
        public Dictionary<int, WeekAndDay> EggTable = new Dictionary<int, WeekAndDay>();

        public MillimetrWeekTable()
        {
            Init();
        }

        public void Init()
        {
            #region length
            lengthMatkaTable.Add(71, new WeekAndDay(5, 0));
            lengthMatkaTable.Add(80, new WeekAndDay(6, 0));
            lengthMatkaTable.Add(91, new WeekAndDay(7, 0));
            lengthMatkaTable.Add(99, new WeekAndDay(8, 0));
            lengthMatkaTable.Add(106, new WeekAndDay(9, 0));
            lengthMatkaTable.Add(112, new WeekAndDay(10, 0));
            lengthMatkaTable.Add(118, new WeekAndDay(11, 0));
            lengthMatkaTable.Add(122, new WeekAndDay(12, 0));
            lengthMatkaTable.Add(135, new WeekAndDay(13, 0));
            #endregion
            #region width
            widthMatkaTable.Add(50, new WeekAndDay(5, 0));
            widthMatkaTable.Add(57, new WeekAndDay(6, 0));
            widthMatkaTable.Add(68, new WeekAndDay(7, 0));
            widthMatkaTable.Add(74, new WeekAndDay(8, 0));
            widthMatkaTable.Add(78, new WeekAndDay(9, 0));
            widthMatkaTable.Add(83, new WeekAndDay(10, 0));
            widthMatkaTable.Add(89, new WeekAndDay(11, 0));
            widthMatkaTable.Add(95, new WeekAndDay(12, 0));
            widthMatkaTable.Add(102, new WeekAndDay(13, 0));
            #endregion
            #region pzr
            PZRMatkaTable.Add(40, new WeekAndDay(5, 0));
            PZRMatkaTable.Add(45, new WeekAndDay(6, 0));
            PZRMatkaTable.Add(49, new WeekAndDay(7, 0));
            PZRMatkaTable.Add(52, new WeekAndDay(8, 0));
            PZRMatkaTable.Add(55, new WeekAndDay(9, 0));
            PZRMatkaTable.Add(58, new WeekAndDay(10, 0));
            PZRMatkaTable.Add(62, new WeekAndDay(11, 0));
            PZRMatkaTable.Add(66, new WeekAndDay(12, 0));
            PZRMatkaTable.Add(70, new WeekAndDay(13, 0));
            #endregion
            #region size
            sizeRMatkaTable.Add(71 * 40 * 50, new WeekAndDay(5, 0));
            sizeRMatkaTable.Add(80 * 45 * 57, new WeekAndDay(6, 0));
            sizeRMatkaTable.Add(91 * 49 * 68, new WeekAndDay(7, 0));
            sizeRMatkaTable.Add(99 * 52 * 74, new WeekAndDay(8, 0));
            sizeRMatkaTable.Add(106 * 55 * 78, new WeekAndDay(9, 0));
            sizeRMatkaTable.Add(112 * 58 * 83, new WeekAndDay(10, 0));
            sizeRMatkaTable.Add(118 * 62 * 89, new WeekAndDay(11, 0));
            sizeRMatkaTable.Add(122 * 66 * 95, new WeekAndDay(12, 0));
            sizeRMatkaTable.Add(135 * 70 * 102, new WeekAndDay(13, 0));
            #endregion
            #region KTR
            KTRTable.Add(4,new WeekAndDay(5,2));
            KTRTable.Add(5,new WeekAndDay(6,1));
            KTRTable.Add(6,new WeekAndDay(6,3));
            KTRTable.Add(7,new WeekAndDay(6,5));
            KTRTable.Add(8,new WeekAndDay(6,6));
            KTRTable.Add(9,new WeekAndDay(7,0));
            KTRTable.Add(10,new WeekAndDay(7,2));

            KTRTable.Add(11,new WeekAndDay(7,3));
            KTRTable.Add(12,new WeekAndDay(7,5));
            KTRTable.Add(13,new WeekAndDay(7,6));
            KTRTable.Add(14,new WeekAndDay(8,1));
            KTRTable.Add(15,new WeekAndDay(8,2));
            KTRTable.Add(16,new WeekAndDay(8,3));
            KTRTable.Add(17,new WeekAndDay(8,4));
            KTRTable.Add(18,new WeekAndDay(8,5));
            KTRTable.Add(19,new WeekAndDay(8,6));
            KTRTable.Add(20,new WeekAndDay(9,0));

            KTRTable.Add(21,new WeekAndDay(9,1));
            KTRTable.Add(22,new WeekAndDay(9,2));
            KTRTable.Add(23,new WeekAndDay(9,3));
            KTRTable.Add(24,new WeekAndDay(9,4));
            KTRTable.Add(25,new WeekAndDay(9,5));
            KTRTable.Add(26,new WeekAndDay(9,6));
            KTRTable.Add(27,new WeekAndDay(10,0));
            KTRTable.Add(28,new WeekAndDay(10,1));
            KTRTable.Add(29,new WeekAndDay(10,1));
            KTRTable.Add(30,new WeekAndDay(10,2));

            KTRTable.Add(31,new WeekAndDay(10,3));
            KTRTable.Add(32,new WeekAndDay(10,4));
            KTRTable.Add(33,new WeekAndDay(10,5));
            KTRTable.Add(34,new WeekAndDay(10,6));
            KTRTable.Add(35,new WeekAndDay(10,6));
            KTRTable.Add(36,new WeekAndDay(11,0));
            KTRTable.Add(37,new WeekAndDay(11,0));
            KTRTable.Add(38,new WeekAndDay(11,1));
            KTRTable.Add(39,new WeekAndDay(11,2));
            KTRTable.Add(40,new WeekAndDay(11,2));

            KTRTable.Add(41,new WeekAndDay(11,3));
            KTRTable.Add(42,new WeekAndDay(11,4));
            KTRTable.Add(43,new WeekAndDay(11,4));
            KTRTable.Add(44,new WeekAndDay(11,5));
            KTRTable.Add(45,new WeekAndDay(11,5));
            KTRTable.Add(46,new WeekAndDay(11,6));
            KTRTable.Add(47,new WeekAndDay(12,0));
            KTRTable.Add(48,new WeekAndDay(12,0));
            KTRTable.Add(49,new WeekAndDay(12,1));
            KTRTable.Add(50,new WeekAndDay(12,2));

            KTRTable.Add(51,new WeekAndDay(12,3));
            KTRTable.Add(52,new WeekAndDay(12,3));
            KTRTable.Add(53,new WeekAndDay(12,4));
            KTRTable.Add(54,new WeekAndDay(12,4));
            KTRTable.Add(55,new WeekAndDay(12,5));
            KTRTable.Add(56,new WeekAndDay(12,5));
            KTRTable.Add(57,new WeekAndDay(12,6));
            KTRTable.Add(58,new WeekAndDay(12,6));
            KTRTable.Add(59,new WeekAndDay(13,0));
            KTRTable.Add(60,new WeekAndDay(13,0));

            KTRTable.Add(61,new WeekAndDay(13,1));
            KTRTable.Add(62,new WeekAndDay(13,2));
            KTRTable.Add(63,new WeekAndDay(13,2));
            KTRTable.Add(64,new WeekAndDay(13,3));
            KTRTable.Add(65,new WeekAndDay(13,3));
            KTRTable.Add(66,new WeekAndDay(13,4));
            KTRTable.Add(67,new WeekAndDay(13,4));
            KTRTable.Add(68,new WeekAndDay(13,5));
            KTRTable.Add(69,new WeekAndDay(13,5));
            KTRTable.Add(70,new WeekAndDay(13,6));

            KTRTable.Add(71,new WeekAndDay(13,6));
            KTRTable.Add(72,new WeekAndDay(14,0));
            KTRTable.Add(73,new WeekAndDay(14,0));
            KTRTable.Add(74,new WeekAndDay(14,1));
            KTRTable.Add(75,new WeekAndDay(14,1));
            KTRTable.Add(76,new WeekAndDay(14,2));
            KTRTable.Add(77,new WeekAndDay(14,3));
            KTRTable.Add(78,new WeekAndDay(14,3));
            KTRTable.Add(79,new WeekAndDay(14,4));
            KTRTable.Add(80,new WeekAndDay(14,4));

            KTRTable.Add(81,new WeekAndDay(14,5));
            KTRTable.Add(86,new WeekAndDay(15,0));
            KTRTable.Add(97,new WeekAndDay(16,0));
            KTRTable.Add(110,new WeekAndDay(17,0));
            KTRTable.Add(120,new WeekAndDay(18,0));
            KTRTable.Add(130,new WeekAndDay(19,0));
            KTRTable.Add(140,new WeekAndDay(20,0));
            KTRTable.Add(209,new WeekAndDay(21,0));
            KTRTable.Add(278,new WeekAndDay(22,0));
            KTRTable.Add(289,new WeekAndDay(23,0));

            #endregion
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
                    correspondingWeekAndDay = GetMinWeekAndDay(KTRTable, value);
                    break;
                case "Egg":
                    correspondingWeekAndDay = GetMinWeekAndDay(EggTable, value);
                    break;
            }
            return correspondingWeekAndDay;
        }
    }
}
