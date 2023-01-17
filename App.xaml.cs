using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace WomenConsulting
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private void Application_DispatcherUnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
        {
            UserDialog.Message(e.Exception.Message);
            var saveError=UserDialog.AskYesNo("Произошла непредвиденная ошибка. Хотите сохранить информацию об ошибке?",
                "Сообщение об ошибке");

            if (saveError)
            {
                FolderBrowserDialog folderDlg = new FolderBrowserDialog();

                // Show the FolderBrowserDialog.  
                DialogResult dialogResult = folderDlg.ShowDialog();
                if (dialogResult == System.Windows.Forms.DialogResult.OK)
                {
                    var errorPath = Path.Combine(folderDlg.SelectedPath,$"{DateTime.Now.ToString().Replace(':','_')}.json");
                    var errorContent = JsonConvert.SerializeObject(e);
                    File.WriteAllText(errorPath, errorContent);
                }
            }
        }
    }
}
