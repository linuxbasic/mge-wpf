using ch.hsr.wpf.gadgeothek.domain;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Data;

namespace me.basig.linus.mge
{

    class CustomerValidationRules : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            Customer customer = (value as BindingGroup).Items[0] as Customer;
            if(customer.Name == "hallo")
            {
                return new ValidationResult(false, "Name can't be hallo");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
    class CustomerNameValidationRules : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || (string)value == "")
            {
                return new ValidationResult(false, "Name can't empty");
            }
            else
            {
                return ValidationResult.ValidResult;
            }
        }
    }
}
