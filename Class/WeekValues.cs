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

        [DisplayName("Масса(5-й перцентиль)")]
        public int perc5_Mass { get; set; }

        [DisplayName("Масса(10-й перцентиль)")]
        public int perc10_Mass { get; set; }

        [DisplayName("Масса(90-й перцентиль)")]
        public int perc90_Mass { get; set; }

        [DisplayName("Бипариетальный размер(5-й перцентиль)")]
        public int perc5_BPR { get; set; }

        [DisplayName("Бипариетальный размер(10-й перцентиль)")]
        public int perc10_BPR { get; set; }

        [DisplayName("Бипариетальный размер(90-й перцентиль)")]
        public int perc90_BPR { get; set; }

        [DisplayName("Длина бедренной кости(5-й перцентиль)")]
        public int perc5_DB { get; set; }

        [DisplayName("Длина бедренной кости(10-й перцентиль)")]
        public int perc10_DB { get; set; }

        [DisplayName("Длина бедренной кости(90-й перцентиль)")]
        public int perc90_DB { get; set; }

        [DisplayName("Окружность живота(5-й перцентиль)")]
        public int perc5_OZh { get; set; }

        [DisplayName("Окружность живота(10-й перцентиль)")]
        public int perc10_OZh { get; set; }

        [DisplayName("Окружность живота(90-й перцентиль)")]
        public int perc90_OZh { get; set; }

        [DisplayName("Длина плеча(5-й перцентиль)")]
        public int perc5_DGK { get; set; }

        [DisplayName("Длина плеча(10-й перцентиль)")]
        public int perc10_DGK { get; set; }

        [DisplayName("Длина плеча(90-й перцентиль)")]
        public int perc90_DGK { get; set; }

        [DisplayName("Копчико-теменной размер(5-й перцентиль)")]
        public int perc5_CopchTemSize { get; set; }

        [DisplayName("Копчико-теменной размер(10-й перцентиль)")]
        public int perc10_CopchTemSize { get; set; }

        [DisplayName("Копчико-теменной размер(90-й перцентиль)")]
        public int perc90_CopchTemSize { get; set; }

        [DisplayName("Длина костей предплечья(5-й перцентиль)")]
        public int perc5_PredPlechLength { get; set; }

        [DisplayName("Длина костей предплечья(10-й перцентиль)")]
        public int perc10_PredPlechLength { get; set; }

        [DisplayName("Длина костей предплечья(90-й перцентиль)")]
        public int perc90_PredPlechLength { get; set; }

        [DisplayName("Длина костей голени(5-й перцентиль)")]
        public int perc5_HipLength { get; set; }

        [DisplayName("Длина костей голени(10-й перцентиль)")]
        public int perc10_HipLength { get; set; }

        [DisplayName("Длина костей голени(90-й перцентиль)")]
        public int perc90_HipLength { get; set; }

        public WeekValues()
        {

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
                $"Копчико-теменной размер: {perc10_CopchTemSize} - {perc90_CopchTemSize} " +
                $"Длина костей предплечья: {perc10_PredPlechLength} - {perc90_PredPlechLength} " +
                $"Длина костей голени: {perc10_HipLength} - {perc90_HipLength}";
        }
    }
}
