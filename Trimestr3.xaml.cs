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
    /// Логика взаимодействия для Trimestr3.xaml
    /// </summary>
    public partial class Trimestr3 : Page
    {
        public Trimestr3()
        {
            InitializeComponent();
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            if (!UserDialog.FetometryGestationFilled(gestationalTime_week.Text, biparietalSize_mm.Text,
            hipLen_mm.Text, bellyCircle_mm.Text, shoulderLenghtMM.Text, legthForearmMM.Text, legthShinMM.Text))
            {
                UserDialog.Message("Срок беременности или поля из фетометрии не заполнены. Заполните и повторите попытку, пожалуйста",
                    "Не все данные заполнены");
                return;
            }
            double shoulderLength = 0.0;
            if (shoulderLenghtMM.Text == "" || double.Parse(shoulderLenghtMM.Text) == 0)
            {
                dynamic shoulderPerc = GlobalSettings.PercentilTbl.GetParameterFromPercentileTableByName(int.Parse(gestationalTime_week.Text),"DPK");
                shoulderLength = (shoulderPerc.percentile10 + shoulderPerc.percentile90) / 2;
            }
            else
            {
                shoulderLength = double.Parse(shoulderLenghtMM.Text);
            }
            double ForearmLength = 0.0;
            if (legthForearmMM.Text == "" || double.Parse(legthForearmMM.Text) == 0)
            {
                dynamic forearmPerc = GlobalSettings.PercentilTbl.GetParameterFromPercentileTableByName(int.Parse(gestationalTime_week.Text), "DPP");
                ForearmLength = (forearmPerc.percentile10 + forearmPerc.percentile90) / 2;
            }
            else
            {
                ForearmLength = double.Parse(legthForearmMM.Text);
            }
            double ShinLength = 0.0;
            if (legthShinMM.Text == "" || double.Parse(legthShinMM.Text) == 0)
            {
                dynamic shinPerc = GlobalSettings.PercentilTbl.GetParameterFromPercentileTableByName(int.Parse(gestationalTime_week.Text), "DGK");
                ShinLength = (shinPerc.percentile10 + shinPerc.percentile90) / 2;
            }
            else
            {
                ShinLength = double.Parse(legthShinMM.Text);
            }
            mass_g.Text = Trimestr.CalculateMass(
                int.Parse(gestationalTime_week.Text),
                double.Parse(biparietalSize_mm.Text),
                double.Parse(hipLen_mm.Text),
                double.Parse(bellyCircle_mm.Text),
                shoulderLength,
                ForearmLength,
                ShinLength).ToString();

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

            var ourNormDPK = GlobalSettings.PercentilTbl.GetParameterFromPercentileTableByName(int.Parse(gestationalTime_week.Text), "DPK");
            SetComboBoxSelectedIndex(shoulderLenghtPerc, ourNormDPK, shoulderLenghtMM);

            var ourNormForearm = GlobalSettings.PercentilTbl.GetParameterFromPercentileTableByName(int.Parse(gestationalTime_week.Text), "DPP");
            SetComboBoxSelectedIndex(legthForearmPerc, ourNormForearm, legthForearmMM);

            var ourNormShin = GlobalSettings.PercentilTbl.GetParameterFromPercentileTableByName(int.Parse(gestationalTime_week.Text), "DKG");
            SetComboBoxSelectedIndex(legthShinProc, ourNormShin, legthShinMM);

            //заполнили предполагаемое количество недель по параметрам
            biparietalSize_week.Text = GlobalSettings.PercentilTbl.GetCorrespondingWeekByNameOfParameter("BPR", double.Parse(biparietalSize_mm.Text)).ToString();
            hipLen_week.Text = GlobalSettings.PercentilTbl.GetCorrespondingWeekByNameOfParameter("DB", double.Parse(hipLen_mm.Text)).ToString();
            bellyCircle_week.Text = GlobalSettings.PercentilTbl.GetCorrespondingWeekByNameOfParameter("OZh", double.Parse(bellyCircle_mm.Text)).ToString();
            mass_week.Text = GlobalSettings.PercentilTbl.GetCorrespondingWeekByNameOfParameter("Mass", double.Parse(mass_g.Text)).ToString();
            shoulderLenghtWeek.Text = GlobalSettings.PercentilTbl.GetCorrespondingWeekByNameOfParameter("DPK", double.Parse(shoulderLenghtMM.Text)).ToString();
            legthForearmWeek.Text = GlobalSettings.PercentilTbl.GetCorrespondingWeekByNameOfParameter("DPP", double.Parse(legthForearmMM.Text)).ToString();
            legthShinWeek.Text = GlobalSettings.PercentilTbl.GetCorrespondingWeekByNameOfParameter("DKG", double.Parse(legthShinMM.Text)).ToString();
        }

        private void SetComboBoxSelectedIndex(ComboBox curComboBox, dynamic percCorridor, TextBox ourValue)
        {
            var currentValue = double.Parse(ourValue.Text);
            if (currentValue <= percCorridor.percentile5)
            {
                curComboBox.SelectedIndex = 0;
            }
            else if (percCorridor.percentile5 < currentValue && currentValue <= percCorridor.percentile10)
            {
                curComboBox.SelectedIndex = 1;
            }
            else if (percCorridor.percentile10 < currentValue && currentValue <= percCorridor.percentile90)
            {
                curComboBox.SelectedIndex = 2;
            }
            else
            {
                curComboBox.SelectedIndex = 3;
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

            if (gestationList.SelectedIndex == 0)
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
            if (gestationList.SelectedIndex == 1)
            {
                var firstTrimPage1 = MainWindow.protocol.fetuses[0].trimestr1.TrimestrPage;

                var firstWeekText = ((TextBox)firstTrimPage1.FindName("gestationalTime_week")).Text;
                var firstDayText = ((TextBox)firstTrimPage1.FindName("gestationalTime_day")).Text;
                var firstDate = (DatePicker)firstTrimPage1.FindName("dateText");

                if (String.IsNullOrEmpty(firstWeekText) || String.IsNullOrEmpty(firstDayText) ||
                    (int.Parse(firstWeekText) == 0 && int.Parse(firstDayText) == 0))
                {
                    firstTrimPage1 = MainWindow.protocol.fetuses[0].trimestr2.TrimestrPage;

                    firstWeekText = ((TextBox)firstTrimPage1.FindName("gestationalTime_week")).Text;
                    firstDayText = ((TextBox)firstTrimPage1.FindName("gestationalTime_day")).Text;
                }

                if (String.IsNullOrEmpty(firstWeekText) || String.IsNullOrEmpty(firstDayText))
                {
                    firstTrimPage1 = MainWindow.protocol.fetuses[0].trimestr2.TrimestrPage;

                    gestationalTime_week.Text = "0";
                    gestationalTime_day.Text = "0";
                    return;
                }


                firstDate = (DatePicker)firstTrimPage1.FindName("dateOfSurvey"); 

                var dateDifference = DateTime.Now - DateTime.Parse(firstDate.Text);
                var difference = dateDifference + TimeSpan.FromDays(int.Parse(firstWeekText) * 7 + int.Parse(firstDayText));
                gestationalTime_week.Text = (difference.Days / 7).ToString();
                gestationalTime_day.Text = (difference.Days - difference.Days / 7 * 7).ToString();

            }

        }

        private void calculateDoplerometryButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(uterineArteriesMM.Text)
                || String.IsNullOrWhiteSpace(umbilicalArteriesMM.Text)
                || String.IsNullOrWhiteSpace(celebralAttitudeMM.Text))
            {
                UserDialog.Message("Срок беременности или поля из доплерометрии не заполнены. Заполните и повторите попытку, пожалуйста",
    "Не все данные заполнены");
                return;
            }

            //заполнили комбобоксы к параметрам
            var ourNormUterine = GlobalSettings.PercentilTbl.GetParameterFromPercentileTableByName(int.Parse(gestationalTime_week.Text), "Uterine");
            SetComboBoxDoplerometrySelectedIndex(uterineArteriesCombo, ourNormUterine, uterineArteriesMM);

            var ourNormUmbilical = GlobalSettings.PercentilTbl.GetParameterFromPercentileTableByName(int.Parse(gestationalTime_week.Text), "Umbilical");
            SetComboBoxDoplerometrySelectedIndex(umbilicalArteriesCom, ourNormUmbilical, umbilicalArteriesMM);

            var ourNormCelebral = GlobalSettings.PercentilTbl.GetParameterFromPercentileTableByName(int.Parse(gestationalTime_week.Text), "Celebral");
            SetComboBoxDoplerometrySelectedIndex(celebralAttitudeComb, ourNormCelebral, celebralAttitudeMM);

            //заполнили значения недели по значению параметра
            uterineArteriesWeek.Text = GlobalSettings.PercentilTbl.GetCorrespondingWeekByNameOfParameter("Uterine", double.Parse(uterineArteriesMM.Text)).ToString();
            umbilicalArteriesWee.Text = GlobalSettings.PercentilTbl.GetCorrespondingWeekByNameOfParameter("Umbilical", double.Parse(umbilicalArteriesMM.Text)).ToString();
        }

        private void SetComboBoxDoplerometrySelectedIndex(ComboBox curComboBox, dynamic percCorridor, TextBox ourValue)
        {
            var currentValue = double.Parse(ourValue.Text);
            if (currentValue <= percCorridor.percentile5)
            {
                curComboBox.SelectedIndex = 0;
            }
            else if (currentValue <= percCorridor.percentile95)
            {
                curComboBox.SelectedIndex = 1;
            }
            else
            {
                curComboBox.SelectedIndex = 2;
            }

        }
    }
}
