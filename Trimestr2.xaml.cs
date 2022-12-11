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
            mass_g.Text = Trimestr.CalculateMass(
                int.Parse(gestationalTime_week.Text),
                double.Parse(biparietalSize_mm.Text),
                double.Parse(hipLen_mm.Text),
                double.Parse(bellyCircle_mm.Text),
                double.Parse(shoulderLenghtMM.Text),
                double.Parse(legthForearmMM.Text),
                double.Parse(legthShinMM.Text)).ToString();
        }

        private void onlyDigits_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }
    }
}
