using System.Globalization;
using System.Windows.Controls;
using System;

namespace Quipu.UI.ValidationRules
{
    public class NonNegatineRule : ValidationRule
    {
        public NonNegatineRule()
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

            if (percentage <= 0)
            {
                return new ValidationResult(false,
                  $"Please enter an non-negative digit.");
            }
            return ValidationResult.ValidResult;
        }
    }
}
