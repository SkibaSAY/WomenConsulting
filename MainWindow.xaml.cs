using Aspose.Words;
using Aspose.Words.Saving;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WomenConsulting.Class;

namespace WomenConsulting
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Trimestr> trimestrs;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void InitPages()
        {
            //Test();
            trimestrs = new List<Trimestr>()
            {
                new Trimestr("1.docx",@"..\..\Шаблоны\1_trimestr.docx",Frame_Trimestr1.Content as Trimestr1),
                new Trimestr("2.docx",@"..\..\Шаблоны\2_trimestr.docx",Frame_Trimestr2.Content as Trimestr2),
                new Trimestr("3.docx",@"..\..\Шаблоны\3-iy_trimestr.docx",Frame_Trimestr3.Content as Trimestr3)
            };
        }

        private void Test()
        {
            var path = "MalenkiySrokFinal.docx";
            var outPath = "MalenkiySrokFinalOut.docx";

            var doc = new Document(path);
            //для полей со списком искать в dropDownitems
            var a = doc.Range.FormFields.Where(x => x.Name.Contains("ПолеСоСписком14")).FirstOrDefault();
            a.Result = "(ректальное)";
        }

        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            mainGrid.RowDefinitions[1].Height = new GridLength(200);
        }

        private void generalData_Collapsed(object sender, RoutedEventArgs e)
        {
            mainGrid.RowDefinitions[1].Height = new GridLength(50);
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            InitPages();
        }
    }
}
