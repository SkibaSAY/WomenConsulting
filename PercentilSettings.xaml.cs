using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WomenConsulting
{
    /// <summary>
    /// Логика взаимодействия для PercentilSettings.xaml
    /// </summary>
    public partial class PercentilSettings : Window
    {
        public WeekValues week;
        public List<ViewWeekPercentil> WeekViews { get; set; }
        public PercentilSettings(WeekValues week)
        {
            InitializeComponent();
            Init(week);
        }

        private void Init(WeekValues week)
        {
            UserDialog.Message($"На данный момент функционал, связанный с окном настроек перцентильных коридоров в разработке." +
    $"\n\r 1.Можно менять настройки, но при возвращении в окно со всеми недельными данными вы не увидете изменений" +
    $", однако внутренние программные данные поменялись - для корретного отображения перезайдите в окно настроек." +
    $"\n\r2.При изменении парцентильных настроек, перед выходом переводите курсор на другой элемент управления, иначе тот элемент, где стоите, не обновится." +
    $"\n\r3.Не записывайте в поля не числа. Пока это не обработано");

            this.week = week;
            var viewProterties = typeof(WeekValues).GetProperties().ToList();
            WeekViews = viewProterties.Select(p => new ViewWeekPercentil(p, this.week)).ToList();
            DataContext = this;
        }
        private void SaveValues()
        {
            //значит нужно спросить , сохранять или нет
            if (WeekViews.Any(x => x.IsNeedUpdate))
            {
                var answer = UserDialog.AskYesNo("Сохранить изменения?");
                if (answer)
                {
                    SavePercentilSettings();
                }
            }
        }
        private void SavePercentilSettings()
        {
            foreach(var week in WeekViews.Where(x=>x.IsNeedUpdate))
            {
                week.Update();
            }
        }
        public class ViewWeekPercentil
        {
            private readonly PropertyInfo _property;
            private WeekValues _weekPercentil;
            public bool IsNeedUpdate
            {
                get { return !Value.Equals(ValueInSettings); }
            }
            public string DisplayName { get; set; }
            public object Value { get; set; }

            public object ValueInSettings
            {
                get { return _property.GetValue(_weekPercentil); }
            }

            public ViewWeekPercentil(PropertyInfo _property, WeekValues _weekPercentil)
            {
                this._property = _property;
                this._weekPercentil = _weekPercentil;
                this.Value = _property.GetValue(_weekPercentil);

                var customAttribute = _property.GetCustomAttribute(typeof(DisplayNameAttribute));
                if (customAttribute!= null)
                {
                    DisplayName = (customAttribute as DisplayNameAttribute).DisplayName;
                }
                else
                {
                    DisplayName = _property.Name;
                }
            }
            public void Update()
            {
                _property.SetValue(_weekPercentil, int.Parse(Value.ToString()));
            }
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            SaveValues();
        }
    }
}
