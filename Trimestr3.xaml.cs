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
            if ((String.IsNullOrEmpty(gestationalTime_week.Text)) ||
                (String.IsNullOrEmpty(BiparietalDiamField.Text)) ||
                (String.IsNullOrEmpty(FemurLengthField.Text)) ||
                (String.IsNullOrEmpty(AbdominalCircField.Text)) ||
                (String.IsNullOrEmpty(shoulderLenghtMM.Text)) ||
                (String.IsNullOrEmpty(legthForearmMM.Text)) ||
                (String.IsNullOrEmpty(legthShinMM.Text)))
            {
                MessageBox.Show("Срок беременности или поля из фетометрии не заполнены. Заполните и повторите попытку, пожалуйста"
                    , "Не все данные заполнены"
                    , MessageBoxButton.OK
                    , MessageBoxImage.Information);
                return;
            }
            MassField.Text = Trimestr.CalculateMass(
                int.Parse(gestationalTime_week.Text),
                double.Parse(BiparietalDiamField.Text),
                double.Parse(FemurLengthField.Text),
                double.Parse(AbdominalCircField.Text),
                double.Parse(shoulderLenghtMM.Text),
                double.Parse(legthForearmMM.Text),
                double.Parse(legthShinMM.Text)).ToString();
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
