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
        public Dictionary<int, WeekAndDay> MatkaTable;
        public Dictionary<int, WeekAndDay> KTRTable;
        public Dictionary<int, WeekAndDay> EggTable;

        public MillimetrWeekTable()
        {
            Init();
        }

        public void Init()
        {

        }
    }
}
