using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WomenConsulting
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Trimestr1 : Page
    {
        public Trimestr1()
        {
            InitializeComponent();
        }

        private void dateOfLastMen_CalendarClosed(object sender, RoutedEventArgs e)
        {
            //возвращаю в общие , поэтому пока комментим
            //var dateDifference = DateTime.Now - dateOfLastMen.SelectedDate;
            //gestationalTime_week.Text = (dateDifference.Value.Days / 7).ToString();
            //gestationalTime_day.Text = (dateDifference.Value.Days - dateDifference.Value.Days / 7 * 7).ToString();
        }
        private void onlyDigits_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void doubleNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && !e.Text.StartsWith(",")) e.Handled = true;
        }
    }
}
