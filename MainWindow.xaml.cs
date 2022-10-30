using Aspose.Words;
using Aspose.Words.Saving;
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
            InitPages();
        }

        private void InitPages()
        {
            Test();
            trimestrs = new List<Trimestr>()
            {

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
    }
}
