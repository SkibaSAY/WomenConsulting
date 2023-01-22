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
        public static void Message(string message, string caption = "")
        {
            System.Windows.MessageBox.Show(
                message 
                , caption
                , System.Windows.MessageBoxButton.OK
                , System.Windows.MessageBoxImage.Information);
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
    
        public static bool FetometryGestationFilled(
            string gestationalTime_week,
            string biparietalSize_mm,
            string hipLen_mm,
            string bellyCircle_mm,
            string shoulderLenghtMM,
            string legthForearmMM,
            string legthShinMM)
        {
            if ((String.IsNullOrWhiteSpace(gestationalTime_week)) ||
                int.Parse(gestationalTime_week) == 0 ||
                (String.IsNullOrWhiteSpace(biparietalSize_mm)) ||
                (String.IsNullOrWhiteSpace(hipLen_mm)) ||
                (String.IsNullOrWhiteSpace(bellyCircle_mm)) ||
                (String.IsNullOrWhiteSpace(shoulderLenghtMM) ||
                (String.IsNullOrWhiteSpace(legthForearmMM)) ||
                (String.IsNullOrWhiteSpace(legthShinMM))))
            {
                return false;
            }
            return true;
        }

        public static bool QuestionAnswerDialog(string question, out string userAnswer, string defaultAnswer = "")
        {
            var inputDialogWindow = new QuestionAnswerDialog
            (
                question: question,
                defaultAnswer: defaultAnswer
            );
            var dialogResult = inputDialogWindow.ShowDialog().Value;

            userAnswer = inputDialogWindow.Answer;
            return dialogResult;
        }
    }
}
