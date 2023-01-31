using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WomenConsulting
{
    public class IsEnableAttribute : Attribute
    {
        public bool IsEnable { get; private set; }
        public IsEnableAttribute(bool state)
        {
            IsEnable = state;
        }
    }
    public class WeekValues
    {
        [DisplayName("Неделя"),IsEnable(false)]
        public int WeekNumber { get; set; }

        [DisplayName("Масса(10-й перцентиль)")]
        public int perc10_Mass { get; set; }

        [DisplayName("Масса(90-й перцентиль)")]
        public int perc90_Mass { get; set; }

        [DisplayName("Бипариетальный размер(10-й перцентиль)")]
        public int perc10_BPR { get; set; }

        [DisplayName("Бипариетальный размер(90-й перцентиль)")]
        public int perc90_BPR { get; set; }

        [DisplayName("Длина бедренной кости(10-й перцентиль)")]
        public int perc10_DB { get; set; }

        [DisplayName("Длина бедренной кости(90-й перцентиль)")]
        public int perc90_DB { get; set; }

        [DisplayName("Окружность живота(10-й перцентиль)")]
        public int perc10_OZh { get; set; }

        [DisplayName("Окружность живота(90-й перцентиль)")]
        public int perc90_OZh { get; set; }

        [DisplayName("Длина плеча(10-й перцентиль)")]
        public int perc10_DGK { get; set; }

        [DisplayName("Длина плеча(90-й перцентиль)")]
        public int perc90_DGK { get; set; }


        [DisplayName("Копчико-теменной размер(10-й перцентиль)")]
        public int perc10_CobchTemSize { get; set; }

        [DisplayName("Копчико-теменной размер(90-й перцентиль)")]
        public int perc90_CobchTemSize { get; set; }

        [DisplayName("Длина костей предплечья(10-й перцентиль)")]
        public int perc10_PredPlechLength { get; set; }

        [DisplayName("Длина костей предплечья(90-й перцентиль)")]
        public int perc90_PredPlechLength { get; set; }

        [DisplayName("Длина костей голени(10-й перцентиль)")]
        public int perc10_HipLength { get; set; }

        [DisplayName("Длина костей голени(90-й перцентиль)")]
        public int perc90_HipLength { get; set; }

        public WeekValues()
        {

        }
        public WeekValues(int number, int perc10_Mass, int perc90_Mass, int perc10_BPR, int perc90_BPR, int perc10_DB, int perc90_DB, int perc10_OZh, int perc90_OZh, int perc10_DGK, int perc90_DGK)
        {
            WeekNumber = number;
            this.perc10_Mass = perc10_Mass;
            this.perc90_Mass = perc90_Mass;
            this.perc10_BPR = perc10_BPR;
            this.perc90_BPR = perc90_BPR;
            this.perc10_DB = perc10_DB;
            this.perc90_DB = perc90_DB;
            this.perc10_OZh = perc10_OZh;
            this.perc90_OZh = perc90_OZh;
            this.perc10_DGK = perc10_DGK;
            this.perc90_DGK = perc90_DGK;
        }
        public override string ToString()
        {
            //var stringList = typeof(WeekValues).GetProperties()
            //    .Select(
            //        x => $"{(x.GetCustomAttribute(typeof(DisplayNameAttribute))!=null ? (x.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute).DisplayName : x.Name)} " 
            //        +$": {x.GetValue(this)}"
            //        ).ToList();

            return $"{WeekNumber}я неделя: Масса: {perc10_Mass} - {perc90_Mass}; " +
                $"Бипариетальный размер: {perc10_BPR} - {perc90_BPR}; " +
                $"Длина бедренной кости: {perc10_DB} - {perc90_DB}; " +
                $"Окружность живота: {perc10_OZh} - {perc90_OZh}; " +
                $"Длина плеча: {perc10_DGK} - {perc90_DGK} " +
                $"Копчико-теменной размер: {perc10_CobchTemSize} - {perc90_CobchTemSize} " +
                $"Длина костей предплечья: {perc10_PredPlechLength} - {perc90_PredPlechLength} " +
                $"Длина костей голени: {perc10_HipLength} - {perc90_HipLength}";
        }
    }
}
