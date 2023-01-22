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
        public static Protocol protocol;

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
                    throw new ArgumentException("Неверно указана временная директория");
                }
                ////отключение/включение кнопки сохранения
                //Save.IsEnabled = !valueIsEmpty;
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
            GlobalSettings.Load();
            CurrentDirectory = GlobalSettings.LastOpenDirectory;
        }

        private void InitProtocol(Protocol newProtocol = null)
        {
            if (newProtocol == null) protocol = new Protocol(CurrentDirectory);
            else protocol = newProtocol;

            DataContext = protocol;
            Fetuses.SelectedIndex = 0;
        }

        private void OpenDirectoryDialog_Click(object sender, RoutedEventArgs e)
        {
            var savedCurrDirectory = CurrentDirectory;
            var lastProtocol = protocol;

            try
            {

            #region окно с протоколами
            var protocolsWindow = new ProtocolListOpen();
            protocolsWindow.ShowDialog();

            var selectedItem = protocolsWindow.ProtocolsList.SelectedItem;
            if (selectedItem == null)
            {
                return;
            }
            #endregion

            else CurrentDirectory = selectedItem.ToString();


                InitProtocol();
            }
            catch (IOException ex)
            {
                //откатили
                CurrentDirectory = savedCurrDirectory;
                UserDialog.Message("Этот документ уже открыт в Word, закройте его и повторите попытку");
            }
            catch(UndefinedPathException ex)
            {
                UserDialog.Message(ex.Message);
                InitProtocol(lastProtocol);
            }

            #region На удалении
            //if (UserDialog.SelectDirectoryPath(out string selectedPath))
            //{
            //    CurrentDirectory = selectedPath;
            //    try
            //    {
            //        InitProtocol();
            //    }
            //    catch(IOException ex)
            //    {
            //        //откатили
            //        CurrentDirectory = savedCurrDirectory;
            //        System.Windows.MessageBox.Show("Этот документ уже открыт в Word, закройте его и повторите попытку");
            //    }
            //}
            #endregion 
        }

        private void onlyDigits_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if ((sender as System.Windows.Controls.TextBox).Text == "0" || String.IsNullOrWhiteSpace((sender as System.Windows.Controls.TextBox).Text))
            {
                (sender as System.Windows.Controls.TextBox).Text = "";
            }
            if (!Char.IsDigit(e.Text, 0)) e.Handled = true;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrEmpty(CurrentDirectory))
            {
                protocol.Save(CurrentDirectory);
            }
            //когда CurrentDirectory пустое, т.е. сейчас сохраняется новый протокол, его нужно проверить на то, что папка такая уже существует
            else
            {
                var surname = protocol.generalSettings.surnameName;
                var path = Path.Combine(GlobalSettings.BaseProtocolsPath, surname);
                if (String.IsNullOrWhiteSpace(surname))
                {
                    UserDialog.Message("Для сохранения заполните поле ФИО и повторите сохранение, пожалуйста.");
                    return;
                }
                //Директория с таким именем уже существует
                else if (Directory.Exists(path))
                {

                }
                else
                {
                    protocol.Save(path);
                }
            }

        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            if(!UserDialog.SelectDirectoryPath(out string selectedPath))
            {
                return;
            }
            CurrentDirectory = selectedPath;
            protocol.Save(CurrentDirectory);
        }

        private void NewProtocol_Click_1(object sender, RoutedEventArgs e)
        {
            ResetCurrentDirectory();
            InitProtocol();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            GlobalSettings.LastOpenDirectory = CurrentDirectory;
            GlobalSettings.Save();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            InitSettings();
            InitProtocol();
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddPlod_Click(object sender, RoutedEventArgs e)
        {
            if (protocol.fetuses.Count < 4)
            {
                protocol.AddFetus(new Fetus($"Плод_{protocol.fetuses.Count + 1}"));
            }
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
            settingsWindow.Owner = this;
            //тут мы ожидаем, когда дочернее окно не закроется,чтобы вернуть фокус на родителя
            if (settingsWindow.ShowDialog() == true)
            {

            }            
        }
    }
}
