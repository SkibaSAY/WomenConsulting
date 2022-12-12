using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WomenConsulting
{
    public static class UserDialog
    {
        public static bool SelectDirectoryPath(out string selectedDirPath,string description = "Выберите директорию")
        {
            selectedDirPath = null;
            FolderBrowserDialog folderDlg = new FolderBrowserDialog();
            folderDlg.ShowNewFolderButton = true;
            folderDlg.Description = description;

            // Show the FolderBrowserDialog.  
            DialogResult result = folderDlg.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                selectedDirPath = folderDlg.SelectedPath;
                return true;
            }
            return false;
        }
        public static void Message(string message)
        {
            System.Windows.MessageBox.Show(message);
        }
        public static bool AskYesNo(string message,string caption="")
        {
            var result = System.Windows.MessageBox.Show(message,caption,button:System.Windows.MessageBoxButton.YesNo);
            switch (result)
            {
                case System.Windows.MessageBoxResult.Yes:
                    return true;
                    break;
                default:
                    return false;
                    break;
            }
        }
    }
}
