using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WomenConsulting
{
    public class FreeDirectoryNameValidator : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var input = (string)value;
            if (String.IsNullOrWhiteSpace(input)) return new ValidationResult(false,"Заполните поле, пожалуйста.");

            var checkedPath = Path.Combine(GlobalSettings.BaseProtocolsPath, input);
            if(!Directory.Exists(checkedPath)) return new ValidationResult(true, "Название протокола свободно.");
            else return new ValidationResult(false, "Название протокола занято, выберите другое, пожалуйста.");
        }
    }
}
