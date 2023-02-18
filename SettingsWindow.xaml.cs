using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
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
using WomenConsulting.Class;

namespace WomenConsulting
{
    public class TabItem
    {
        public string Name { get; set; }
        public List<MillimetrTableRow> Table { get; set; }
        public TabItem()
        {

        }
    }
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window,INotifyPropertyChanged
    {
        public Dictionary<int, WeekValues> WeekValues
        {
            get { return GlobalSettings.PercentilTbl.Weeks; }
        }

        public List<TabItem> TablesWeekByMm
        {
            get
            {
                var millimetrTable = GlobalSettings.MillimetrTbl;
                var tables = millimetrTable.GetType().GetProperties().Where(p => p.PropertyType.Equals(typeof(MyList<MillimetrTableRow>)))
                    .Select(p =>
                    new TabItem{
                        Name = p.GetCustomAttribute(typeof(DisplayNameAttribute)) != null ? (p.GetCustomAttribute(typeof(DisplayNameAttribute)) as DisplayNameAttribute).DisplayName : "Таблица",
                        Table =  (List<MillimetrTableRow>)p.GetValue(millimetrTable)
                    }
                ).ToList();
                return tables;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public SettingsWindow()
        {
            InitializeComponent();
            Init();
        }
        public void Init()
        {
            List<String> Doctors = GlobalSettings.GetDoctors();
            foreach (var item in Doctors)
            {
                DoctorsList.Items.Add(item);
            }
            LastOpenLabel.Content = "Последняя открытая директория:" + GlobalSettings.LastOpenDirectory;
            BasePathLabel.Content = "Базовая директория:" + GlobalSettings.BaseProtocolsPath;
            FormulaConstA.Content = "Значение константы A:" + GlobalSettings.ConstA;
            FormulaConstB.Content = "Значение константы B:" + GlobalSettings.ConstB;
            NewConstABox.Text = GlobalSettings.ConstA.ToString();
            NewConstBBox.Text = GlobalSettings.ConstB.ToString();
            DataContext = this;
        }

        private void AddDoctor_Click(object sender, RoutedEventArgs e)
        {
            AddDoctorWindow addDoctorWindow = new AddDoctorWindow();
            addDoctorWindow.ShowDialog();
            if ((bool)addDoctorWindow.DialogResult)
            {
                GlobalSettings.AddDoctor(addDoctorWindow.DoctorName);
                DoctorsList.Items.Add(addDoctorWindow.DoctorName);
            }
        }
        private void RemoveDoctor_Click(object sender, RoutedEventArgs e)
        {
            if (DoctorsList.SelectedItem != null)
            {
                string msgtext = $"Вы точно хотите удалить выбранного врача?";
                string txt = "";
                MessageBoxButton button = MessageBoxButton.YesNo;
                MessageBoxResult result = System.Windows.MessageBox.Show(msgtext, txt, button);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        GlobalSettings.RemoveDoctor(DoctorsList.SelectedItem.ToString());
                        DoctorsList.Items.Remove(DoctorsList.SelectedItem);
                        break;
                    case MessageBoxResult.No:

                        break;
                }
            }
        }
        private void ConstSaveButton_Click(object sender, RoutedEventArgs e)
        {
            GlobalSettings.ConstA = double.Parse(NewConstABox.Text);
            GlobalSettings.ConstB = double.Parse(NewConstBBox.Text);
            NewConstABox.Text = GlobalSettings.ConstA.ToString();
            NewConstBBox.Text = GlobalSettings.ConstB.ToString();
            FormulaConstA.Content = "Значение константы A:" + GlobalSettings.ConstA;
            FormulaConstB.Content = "Значение константы B:" + GlobalSettings.ConstB;
        }
        private void ConstCancelButton_Click(object sender, RoutedEventArgs e)
        {
            NewConstABox.Text = GlobalSettings.ConstA.ToString();
            NewConstBBox.Text = GlobalSettings.ConstB.ToString();
        }
        private void ChangeBasePath_Click(object sender, RoutedEventArgs e)
        {
            if (UserDialog.SelectDirectoryPath
                        (
                        out string selectedPath,
                        description: "Выберете базовую директорию, в которой будут храниться все протоколы по умолчанию."
                        )
                    )
            {
                GlobalSettings.BaseProtocolsPath = selectedPath;
            }
            BasePathLabel.Content = "Базовая директория:" + GlobalSettings.BaseProtocolsPath;
        }

        //отобразить окно с выбранным перцентильным коридором
        private void WeekValuesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = (ListBox)sender;
            if (listBox.SelectedItem == null) return;
            var selectedWeek = ((KeyValuePair<int, WeekValues>)listBox.SelectedItem).Value;
            var weekPercentilWindow = new PercentilSettings(selectedWeek);
            weekPercentilWindow.Owner = this;

            if(weekPercentilWindow.ShowDialog() == true)
            {

            }
            listBox.SelectedItem = null;
        }
        private void doubleNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if ((sender as TextBox).Text == "0" || String.IsNullOrWhiteSpace((sender as TextBox).Text))
            {
                (sender as TextBox).Text = "";
            }
            if (!Char.IsDigit(e.Text, 0) && !e.Text.StartsWith(",") ||
                (sender as TextBox).Text.Contains(",") && e.Text.StartsWith(",")) e.Handled = true;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            GlobalSettings.Save();
        }
    }
}
