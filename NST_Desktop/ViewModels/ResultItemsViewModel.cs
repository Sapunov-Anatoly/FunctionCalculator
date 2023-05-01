using System.ComponentModel;
using NST_Desktop.Models;

namespace NST_Desktop.ViewModels
{
    /// <summary> Класс модели представления для вычисления функций. </summary>
    public class ResultItems : INotifyPropertyChanged
    {
        /// <summary> Выбранная функция. </summary>
        private MathFunction selected_function;

        /// <summary> Результат вычисления функции. </summary>
        private double _f;

        /// <summary> Значение X. </summary>
        private double _x;

        /// <summary> Значение Y. </summary>
        private double _y;

        /// <summary> Результат вычисления функции. </summary>
        public double F
        {
            get => _f;
            set
            {
                if (_f != value)
                {
                    _f = value;
                    OnPropertyChanged(nameof(F));
                }
            }
        }

        /// <summary> Значение X. </summary>
        public double X
        {
            get => _x;
            set
            {
                if (_x != value)
                {
                    _x = value;
                    OnPropertyChanged(nameof(X));
                    OnPropertyChanged(nameof(F));
                }
            }
        }

        /// <summary> Значение Y. </summary>
        public double Y
        {
            get => _y;
            set
            {
                if (_y != value)
                {
                    _y = value;
                    OnPropertyChanged(nameof(Y));
                    OnPropertyChanged(nameof(F));
                }
            }
        }

        /// <summary>
        /// Обновляет результат вычисления функции.
        /// </summary>
        /// <param name="function"> Математическая функция. </param>
        public void UpdateResult(MathFunction function)
        {
            if (function != null)
            {
                selected_function = function;
                F = (double)(function.FunctionWithXY(X, Y));
            }
        }

        /// <summary> Определяет событие INotifyPropertyChanged. </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Обновляет элементы пользовательского интерфейса и высчитывает значение функции при изменении X или Y.
        /// </summary>
        /// <param name="propertyName"> Имя обновляемого элемента. </param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            if (propertyName == nameof(X) || propertyName == nameof(Y))
            {
                if (selected_function != null)
                {
                    F = (double)(selected_function.FunctionWithXY(X, Y));
                }
            }
        }
    }
}
