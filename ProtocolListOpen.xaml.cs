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
        public string BaseProtocolsDirectory
        {
            get { return GlobalSettings.BaseProtocolsPath; }
            set 
            { 
                GlobalSettings.BaseProtocolsPath = value;
                OnPropertyChanged("BaseProtocolsDirectory");
            }
        }
        private List<DirectoryInfo> _protocolDirs;
        public List<DirectoryInfo> ProtocolDirs
        {
            get { return _protocolDirs; }
            set
            {
                _protocolDirs = value;
                OnPropertyChanged("ProtocolDirs");
            }
        }

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ProtocolListOpen()
        {
            InitializeComponent();
            InitPage();
        }
        private void InitPage()
        {
            ProtocolDirs = Directory.GetDirectories(BaseProtocolsDirectory).Select(path=>new DirectoryInfo(path)).ToList();
            DataContext = this;
        }

        private void ProtocolsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.Close();
        }

        private void searchBtn_Click(object sender, RoutedEventArgs e)
        {
            var searchText = searchName.Text.ToLower();
            InitPage();
            if (!String.IsNullOrEmpty(searchText))
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
            }
        }

        private void BaseDirButton_Click(object sender, RoutedEventArgs e)
        {
            UserDialog.SelectDirectoryPath(out string selectedDirPath, "Выберите базовую директорию.");
            if (selectedDirPath != null)
            {
                BaseProtocolsDirectory = selectedDirPath;
                InitPage();
            }
        }
    }
}
