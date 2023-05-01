using System.Globalization;
using System.Windows.Controls;

namespace NST_Desktop.HelperClasses
{
    /// <summary>
    /// Класс, предоставляющий метод для осуществления валидации данных, вводимых пользователем в DataGrid.
    /// </summary>
    public class DataGridValidationRule : ValidationRule
    {
        /// <summary>
        ///  Метод, используемый для валидации введенных данных в DataGrid
        /// </summary>
        /// <param name="value"> Объект, содержащий введенные данные </param>
        /// <param name="cultureInfo"> Объект, содержащий сведения о културе</param>
        /// <returns> Объект ValidationResult, содержащий результаты валидации. </returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null || !int.TryParse(value.ToString(), out int result))
            {
                return new ValidationResult(false, "Введите число!");
            }

            return ValidationResult.ValidResult;
        }
    }
}
