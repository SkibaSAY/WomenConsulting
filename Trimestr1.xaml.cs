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


        private void dateOfLastMen_LostFocus(object sender, RoutedEventArgs e)
        {
            var dateDifference = DateTime.Now - dateOfLastMen.SelectedDate;
            gestationalTime_week.Text = (dateDifference.Value.Days / 7).ToString();
            gestationalTime_day.Text = (dateDifference.Value.Days - dateDifference.Value.Days / 7 * 7).ToString();
        }
    }
}
