using System;
using System.Collections.Generic;
using System.Globalization;
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
        private void onlyDigits_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if((sender as TextBox).Text == "0" || String.IsNullOrWhiteSpace((sender as TextBox).Text))
            {
                (sender as TextBox).Text = "";
            }
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
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

        private void calculateGestationalTime_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(MainWindow.protocol.generalSettings.dateOfLastMen))
            {
                gestationalTime_week.Text = "0";
                gestationalTime_day.Text = "0";
                return;
            }

            var dateDifference = DateTime.Now - DateTime.Parse(MainWindow.protocol.generalSettings.dateOfLastMen, CultureInfo.CreateSpecificCulture("en-US"));
            gestationalTime_week.Text = (dateDifference.Days / 7).ToString();
            gestationalTime_day.Text = (dateDifference.Days - dateDifference.Days / 7 * 7).ToString();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!UserDialog.FetometryGestationFilled(gestationalTime_week.Text,biparietalDiameterMM.Text, 
                femurLenghtMM.Text,circumferenceMM.Text, shoulderLenghtMM.Text, legthForearmMM.Text, legthShinMM.Text))
            {
                UserDialog.Message("Срок беременности или поля из фетометрии не заполнены. Заполните и повторите попытку, пожалуйста",
                    "Не все данные заполнены");
                return;
            }

            //заполнили предполагаемое количество недель по параметрам
            biparietalDiameterWe.Text = GlobalSettings.PercentilTbl.GetCorrespondingWeekByNameOfParameter("BPR", double.Parse(biparietalDiameterMM.Text)).ToString();
            femurLenghtWeek.Text = GlobalSettings.PercentilTbl.GetCorrespondingWeekByNameOfParameter("DB", double.Parse(femurLenghtMM.Text)).ToString();
            circumferenceWeek.Text = GlobalSettings.PercentilTbl.GetCorrespondingWeekByNameOfParameter("OZh", double.Parse(circumferenceMM.Text)).ToString();
            shoulderLenghtWeek.Text = GlobalSettings.PercentilTbl.GetCorrespondingWeekByNameOfParameter("DPK", double.Parse(shoulderLenghtMM.Text)).ToString();
        }
    }
}
