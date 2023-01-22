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
using WomenConsulting.Class;

namespace WomenConsulting
{
    /// <summary>
    /// Логика взаимодействия для Trimestr2.xaml
    /// </summary>
    public partial class Trimestr2 : Page
    {
        public Trimestr2()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!UserDialog.FetometryGestationFilled(gestationalTime_week.Text, biparietalSize_mm.Text,
            hipLen_mm.Text, bellyCircle_mm.Text, shoulderLenghtMM.Text, legthForearmMM.Text,
            legthShinMM.Text))
            {
                UserDialog.Message("Срок беременности или поля из фетометрии не заполнены. Заполните и повторите попытку, пожалуйста",
                    "Не все данные заполнены");
                return;
            }

            mass_g.Text = Trimestr.CalculateMass(
                int.Parse(gestationalTime_week.Text),
                double.Parse(biparietalSize_mm.Text),
                double.Parse(hipLen_mm.Text),
                double.Parse(bellyCircle_mm.Text),
                double.Parse(shoulderLenghtMM.Text),
                double.Parse(legthForearmMM.Text),
                double.Parse(legthShinMM.Text)).ToString();

            CalculatePercentileTable();
        }

        private void CalculatePercentileTable()
        {
            //заполнили комбобоксы к параметрам
            var ourNormBPR = GlobalSettings.PercentilTbl.GetParameterFromPercentileTableByName(int.Parse(gestationalTime_week.Text), "BPR");
            SetComboBoxSelectedIndex(biparietalSizePerc, ourNormBPR, biparietalSize_mm);

            var ourNormDB = GlobalSettings.PercentilTbl.GetParameterFromPercentileTableByName(int.Parse(gestationalTime_week.Text), "DB");
            SetComboBoxSelectedIndex(hipLenPerc, ourNormDB, hipLen_mm);

            var ourNormOZh = GlobalSettings.PercentilTbl.GetParameterFromPercentileTableByName(int.Parse(gestationalTime_week.Text), "OZh");
            SetComboBoxSelectedIndex(bellyCirclePerc, ourNormOZh, bellyCircle_mm);

            var ourNormMass = GlobalSettings.PercentilTbl.GetParameterFromPercentileTableByName(int.Parse(gestationalTime_week.Text), "Mass");
            SetComboBoxSelectedIndex(massPerc, ourNormMass, mass_g);

            var ourNormDGK = GlobalSettings.PercentilTbl.GetParameterFromPercentileTableByName(int.Parse(gestationalTime_week.Text), "DGK");
            SetComboBoxSelectedIndex(shoulderLenghtPerc, ourNormDGK, shoulderLenghtMM);

            //заполнили предполагаемое количество недель по параметрам
            biparietalSize_week.Text    = GlobalSettings.PercentilTbl.GetCorrespondingWeekByNameOfParameter("BPR", double.Parse(biparietalSize_mm.Text)).ToString();
            hipLen_week.Text            = GlobalSettings.PercentilTbl.GetCorrespondingWeekByNameOfParameter("DB", double.Parse(hipLen_mm.Text)).ToString();
            bellyCircle_week.Text       = GlobalSettings.PercentilTbl.GetCorrespondingWeekByNameOfParameter("OZh", double.Parse(bellyCircle_mm.Text)).ToString();
            mass_week.Text              = GlobalSettings.PercentilTbl.GetCorrespondingWeekByNameOfParameter("Mass", double.Parse(mass_g.Text)).ToString();
            shoulderLenghtWeek.Text     = GlobalSettings.PercentilTbl.GetCorrespondingWeekByNameOfParameter("DGK", double.Parse(shoulderLenghtMM.Text)).ToString();
        }

        private void SetComboBoxSelectedIndex(ComboBox curComboBox, int[] percCorridor, TextBox ourValue)
        {
            var currentValue = double.Parse(ourValue.Text);
            if (currentValue < percCorridor[0])
            {
                curComboBox.SelectedIndex = 1;
            }
            else if (currentValue > percCorridor[1])
            {
                curComboBox.SelectedIndex = 2;
            }
            else
            {
                curComboBox.SelectedIndex = 0;
            }
        }


        private void onlyDigits_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if ((sender as TextBox).Text == "0" || String.IsNullOrWhiteSpace((sender as TextBox).Text))
            {
                (sender as TextBox).Text = "";
            }
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
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
    }
}
