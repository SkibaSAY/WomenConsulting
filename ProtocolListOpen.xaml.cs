using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class ProtocolListOpen : Window, INotifyPropertyChanged
    {
        private string protocolsPath;


        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
        public void UpdateBindings()
        {
            OnPropertyChanged("ProtocolDirs");
        }
        public event PropertyChangedEventHandler PropertyChanged;

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

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            var searchText = searchName.Text.ToLower();
            if (String.IsNullOrEmpty(searchText))
            {
                InitPage();
                UpdateBindings();
            }
            else
            {
                var findedProtocols = new List<DirectoryInfo>();
                foreach(var protocolInfo in ProtocolDirs)
                {
                    if (protocolInfo.Name.ToLower().Contains(searchText))
                    {
                        findedProtocols.Add(protocolInfo);
                    }
                }
                ProtocolDirs = findedProtocols;
                UpdateBindings();
            }
        }
    }
}
