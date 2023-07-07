using System;
using System.Globalization;
using System.Windows.Controls;

namespace Quipu.UI.ValidationRules
{
    public class PercentageRule : ValidationRule
    {
        public PercentageRule()
        {
        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var percentage = 0.0d;

            try
            {
                if (((string)value).Length > 0)
                    percentage = double.Parse((string)value);
            }
            catch (Exception e)
            {
                return new ValidationResult(false, $"Illegal characters or {e.Message}");
            }

            if ((percentage <= 0) || (percentage > 100))
            {
                return new ValidationResult(false,
                  $"Please enter an percentage in the range: 0-100.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
