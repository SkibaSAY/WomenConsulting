using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WomenConsulting
{
    public class NumberValidator : ValidationRule
    {
        public int? Min { get; set; } = null;
        public int? Max { get; set; } = null;
        public NumberValidator()
        {

        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var inputNumber = 0;
            var success = false;
            if(value is string)
            {
                var inputStr = (string)value;
                if (inputStr.Length == 0) success = true;
                else if (int.TryParse(inputStr, out inputNumber))
                {
                    //success = !error
                    success = !(
                        (Min != null && (Min >= inputNumber))
                        || (Max != null && (Max <= inputNumber))
                        );                        
                }                  
            }
            if (success) return ValidationResult.ValidResult;
            else return new ValidationResult(false,"Вводите только целые числа");
        }
    }
}
