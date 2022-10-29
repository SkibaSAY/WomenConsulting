using System;
using System.Collections.Generic;
using System.IO;
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
using Xceed.Words.NET;

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
            Test();
            trimestrs = new List<ITrimestr>()
            {

            };
        }

        private void Test()
        {
            var path = "MalenkiySrokFinal.docx";

            using (var fs = new FileStream(path,FileMode.Open))
            {
                var doc = DocX.Load(fs);
            }
        }
    }
}
