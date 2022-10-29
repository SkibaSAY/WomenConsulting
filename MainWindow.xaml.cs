using GemBox.Document;
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
using WomenConsulting.Interfaces;

namespace WomenConsulting
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<ITrimestr> trimestrs;
        public MainWindow()
        {
            InitializeComponent();
            InitPages();
        }

        private void InitPages()
        {
            //инициализация бесплатной версии GemBox
            ComponentInfo.SetLicense("FREE-LIMITED-KEY");

            trimestrs = new List<ITrimestr>()
            {

            };
        }
    }
}
