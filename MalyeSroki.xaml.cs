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
    public partial class MalyeSroki : Page
    {
        public MalyeSroki()
        {
            InitializeComponent();
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
            if (!e.Text.StartsWith(",") && (sender as TextBox).Text == "0" || String.IsNullOrWhiteSpace((sender as TextBox).Text))
            {
                (sender as TextBox).Text = "";
            }
            if (!Char.IsDigit(e.Text, 0) && !e.Text.StartsWith(",") ||
                (sender as TextBox).Text.Contains(",") && e.Text.StartsWith(",")) e.Handled = true;
        }
        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            int LeftVolume;
            if (LengthOfLeftOvary.Text == "" || WidthOfLeftOvary.Text == "" || HeightOfLeftOvary.Text == "")
            {
                LeftVolume = 0;
            }
            else
            {
                LeftVolume = int.Parse(LengthOfLeftOvary.Text) * int.Parse(WidthOfLeftOvary.Text) * int.Parse(HeightOfLeftOvary.Text);
            }
            VolumeOfLeftOvary.Text = LeftVolume.ToString();
            int RightVolume;
            if (LengthOfRightOvary.Text == "" || WidthOfRightOvary.Text == "" || HeightOfRightOvary.Text == "")
            {
                RightVolume = 0;
            }
            else
            {
                RightVolume = int.Parse(LengthOfRightOvary.Text) * int.Parse(WidthOfRightOvary.Text) * int.Parse(HeightOfRightOvary.Text);
            }
            VolumeOfRightOvary.Text = RightVolume.ToString();
        }

        private void calculateTimeButton_Click(object sender, RoutedEventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(diameterOfFertileEgg.Text))
            {
                var weekAndDay = GlobalSettings.MillimetrTbl.GetWeekFromValue(int.Parse(diameterOfFertileEgg.Text), "Egg");
                gestationOfEggWeek.Text = weekAndDay.Weeks.ToString();
                gestationOfEggDay.Text = weekAndDay.Days.ToString();
            }

            if (!String.IsNullOrWhiteSpace(ktr.Text))
            {
                var weekAndDay = GlobalSettings.MillimetrTbl.GetWeekFromValue(int.Parse(ktr.Text), "KTR");
                gestationKTRWeek.Text = weekAndDay.Weeks.ToString();
                gestationKTRDay.Text = weekAndDay.Days.ToString();
            }
            if (!String.IsNullOrWhiteSpace(uterineLengthMM.Text)
                && !String.IsNullOrWhiteSpace(uterinePZRMM.Text)
                && !String.IsNullOrWhiteSpace(uterineWidthMM.Text))
            {
                var size = int.Parse(uterineLengthMM.Text) * int.Parse(uterinePZRMM.Text) * int.Parse(uterineWidthMM.Text);
                var weekAndDay = GlobalSettings.MillimetrTbl.GetWeekFromValue(size, "Matka");
                increasedTo.Text = weekAndDay.Weeks.ToString();
            }

        }
    }
}
