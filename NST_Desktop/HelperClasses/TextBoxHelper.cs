using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NST_Desktop.HelperClasses
{
    /// <summary>
    /// Класс, представляющий статические методы и свойства для работы с TextBox. 
    /// </summary>
    public static class TextBoxHelper
    {
        /// <summary>
        /// Зависимое свойство, определяющее должен ли TextBox проверять введенное значение на соответствие числу.
        /// </summary>
        public static readonly DependencyProperty NumberValidationProperty = DependencyProperty.RegisterAttached(
                "NumberValidation",
                typeof(bool),
                typeof(TextBoxHelper),
                new PropertyMetadata(false, OnNumberValidationChanged));

        /// <summary>
        /// Возвращает значение свойства NumberValidationProperty у TextBox.
        /// </summary>
        /// <param name="obj"> Предоставляет объект TextBox. </param>
        /// <returns> true, если установлена проверка на соответствие числу, иначе false. </returns>
        public static bool GetNumberValidation(DependencyObject obj)
        {
            return (bool)obj.GetValue(NumberValidationProperty);
        }

        /// <summary>
        ///  Устанавливает значение свойства NumberValidationProperty у TextBox.
        /// </summary>
        /// <param name="obj"> Предоставляет объект TextBox. </param>
        /// <param name="value"> true, если необходима проверка на соответствие числу, иначе false. </param>
        public static void SetNumberValidation(DependencyObject obj, bool value)
        {
            obj.SetValue(NumberValidationProperty, value);
        }

        /// <summary>
        /// Обрабатывает изменение значения свойства NumberValidationProperty.
        /// </summary>
        /// <param name="d"> Объект, у которого произошло изменение свойства. </param>
        /// <param name="e"> Аргумент, содержащий информацию об изменении свойства. </param>
        private static void OnNumberValidationChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            var textBox = d as TextBox;

            if (textBox == null)
            {
                return;
            }

            if ((bool)e.NewValue)
            {
                textBox.PreviewTextInput += TextBoxOnPreviewTextInput;
                DataObject.AddPastingHandler(textBox, TextBoxOnPaste);
            }
            else
            {
                textBox.PreviewTextInput -= TextBoxOnPreviewTextInput;
                DataObject.RemovePastingHandler(textBox, TextBoxOnPaste);
            }
        }

        /// <summary>
        /// Обрабатывает событие вставки текста.
        /// </summary>
        /// <param name="sender"> Источник события. </param>
        /// <param name="e"> Аргументы события. </param>
        private static void TextBoxOnPaste(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                var text = (string)e.DataObject.GetData(typeof(string));

                if (!IsValid(text))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        /// <summary>
        /// Обрабатывает событие набора текста.
        /// </summary>
        /// <param name="sender"> Источник события. </param>
        /// <param name="e"> Аргументы события TextCompositionEventArgs, содержащие информацию о вводимом тексте. </param>
        private static void TextBoxOnPreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsValid(e.Text);
        }

        /// <summary>
        /// Проверяет, является ли переданный текст числом.
        /// </summary>
        /// <param name="text"> Текст, который нужно проверить на число. </param>
        /// <returns> true, если переданный текст является числом, иначе false. </returns>
        private static bool IsValid(string text)
        {
            return int.TryParse(text, out int result);
        }
    }
}