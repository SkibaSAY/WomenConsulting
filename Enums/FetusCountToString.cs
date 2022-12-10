using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WomenConsulting
{
    public enum StringFetusCount
    {
        Один = 1,
        Двойня = 2,
        Тройня = 3,
        Четверо = 4,
        Пятеро = 5,
        Шестеро = 6,
        Семеро = 7
    }
    public static class FetusCount
    {
        public static string GetStringFetusCount(int fetusCount)
        {
            var result = Enum.GetName(typeof(StringFetusCount), fetusCount);
            if (result == null) result = fetusCount.ToString();
            return result;
        }
    }
}
