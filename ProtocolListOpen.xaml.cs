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
using System.Windows.Shapes;

namespace WomenConsulting
{
    /// <summary>
    /// Логика взаимодействия для ProtocolListOpen.xaml
    /// </summary>
    public partial class ProtocolListOpen : Window
    {
        private string protocolsPath;
        public List<DirectoryInfo> ProtocolDirs { get; set; }

        public ProtocolListOpen(string protocolsPath)
        {
            InitializeComponent();
            this.protocolsPath = protocolsPath;
            InitPage();
        }
        private void InitPage()
        {
            ProtocolDirs = Directory.GetDirectories(protocolsPath).Select(path=>new DirectoryInfo(path)).ToList();
            DataContext = this;
        }

        private void ProtocolsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Close();
        }
    }
}
