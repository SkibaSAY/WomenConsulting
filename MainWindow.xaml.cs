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
        private List<Trimestr> trimestrs;

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
            //Test();
            trimestrs = new List<Trimestr>()
            {
                new Trimestr(Path.Combine(CurrentDirectory,"1.docx"),@"..\..\Шаблоны\1_trimestr.docx",Frame_Trimestr1.Content as Trimestr1),
                new Trimestr(Path.Combine(CurrentDirectory,"2.docx"),@"..\..\Шаблоны\2_trimestr.docx",Frame_Trimestr2.Content as Trimestr2),
                new Trimestr(Path.Combine(CurrentDirectory,"3.docx"),@"..\..\Шаблоны\3-iy_trimestr.docx",Frame_Trimestr3.Content as Trimestr3)
            };
        }

        private void OpenDirectoryDialog_Click(object sender, RoutedEventArgs e)
        {
            if(SelectDirectoryPath())
                InitPages();
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
            foreach (var trimestr in trimestrs)
            {
                trimestr.SaveTrimestr(CurrentDirectory);
            }
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
    }
}
