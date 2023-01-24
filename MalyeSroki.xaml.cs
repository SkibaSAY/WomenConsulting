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
    }
}
