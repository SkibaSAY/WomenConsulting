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
using Microsoft.Win32;
using WomenConsulting.Class;
using System.Windows.Forms;
using Path = System.IO.Path;

namespace WomenConsulting
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Protocol protocol;

        private string currentDirectory;

        public string CurrentDirectory
        {
            get
            {
                return currentDirectory;
            }
            /*
             Пустое значение при создании нового протокола => нужно отключить кнопку простого сохранения
             Если значение непустое, то значение должно быть корректным путём, тогда кнопка сохранения будет 
             активна
             */
            set
            {
                var valueIsEmpty = String.IsNullOrEmpty(value);
                if (!valueIsEmpty && !Directory.Exists(value))
                {
                    throw new ArgumentException("Смотрите, что записываете в переменную с директорией");
                }
                //отключение/включение кнопки сохранения
                Save.IsEnabled = !valueIsEmpty;
                currentDirectory = value;
            }
        }

        private void ResetCurrentDirectory()
        {
            CurrentDirectory = "";
        }

        public MainWindow()
        {
            InitializeComponent();
        }
        private void InitSettings()
        {
            Settings.Load();
            CurrentDirectory = Settings.LastOpenDirectory;
        }

        private void InitPages()
        {
            protocol = new Protocol(CurrentDirectory);
            DataContext = protocol;
            Fetuses.SelectedIndex = 0;
        }

        private void OpenDirectoryDialog_Click(object sender, RoutedEventArgs e)
        {
            var savedCurrDirectory = CurrentDirectory;
            if (SelectDirectoryPath())
            {
                try
                {
                    InitPages();
                }
                catch(IOException ex)
                {
                    //откатили
                    CurrentDirectory = savedCurrDirectory;
                    System.Windows.MessageBox.Show("Этот документ уже открыт в Word, закройте его и повторите попытку");
                }
            }

        }
        private bool SelectDirectoryPath()
        {
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;

            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                CurrentDirectory = folderDlg.SelectedPath;
                return true;
            }
            return false;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            protocol.Save(CurrentDirectory);
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            if(SelectDirectoryPath()) 
                Save_Click(sender, e);
        }

        private void NewProtocol_Click_1(object sender, RoutedEventArgs e)
        {
            ResetCurrentDirectory();
            InitPages();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            Settings.LastOpenDirectory = CurrentDirectory;
            Settings.Save();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitSettings();
            InitPages();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddPlod_Click(object sender, RoutedEventArgs e)
        {
            protocol.AddFetus(new Fetus($"Плод_{protocol.fetuses.Count + 1}"));
        }

        private void DeletePlod_Click(object sender, RoutedEventArgs e)
        {
            if (protocol.fetuses.Count == 1)
            {
                System.Windows.MessageBox.Show("Вы не можете удалить из протокола единственный плод.");
                return;
            }
            protocol.DeleteFetus(Fetuses.SelectedIndex);
        }
        private void OpenSettings_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow settingsWindow = new SettingsWindow();
            settingsWindow.Show();
            settingsWindow.Owner = this;
        }
    }
}
