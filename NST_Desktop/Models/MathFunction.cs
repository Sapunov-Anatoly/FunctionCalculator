using System;
using System.Collections.Generic;
namespace NST_Desktop.Models
{
    /// <summary> 
    /// Класс, представляющий модель для функций. 
    /// </summary>
    public class MathFunction
    {
        /// <summary> 
        /// Имя функции.
        /// </summary>
        public string FunctionName { get; }

        /// <summary> 
        /// Коэффициент A. 
        /// </summary>
        public double A { get; set; }

        /// <summary> 
        /// Коэффициент B. 
        /// </summary>
        public double B { get; set; }

        /// <summary>
        /// Коэффициент C.
        /// </summary>
        public int C { get; set; }

        /// <summary> 
        /// Список коэффициентов C.
        /// </summary>
        public List<int> CoefficientsC { get; }

        /// <summary>
        /// Задает функцию из пяти аргументов. 
        /// </summary>
        public Func<double, double, double, double, double, double> Function { get; }

        /// <summary> 
        /// Задает функцию из пяти аргументов, принимая только X и Y при вызове 
        /// </summary>
        public Func<double, double, double> FunctionWithXY => (x, y) => Function(A, B, C, x, y);

        /// <summary>
        /// Конструктор модели, принимающий параметры для инициализации объекта.
        /// </summary>
        /// <param name="name"> Имя функции. </param>
        /// <param name="a"> Коэффициент A. </param>
        /// <param name="b"> Коэффициент B. </param>
        /// <param name="c"> Коэффициент C. </param>
        /// <param name="cVariants"> Список коэффициентов C. </param>
        /// <param name="function"> Функция для вычисления результата f(x,y) </param>
        public MathFunction(string name, double a, double b, int c, List<int> cVariants, Func<double, double, double, double, double, double> function)
        {
            FunctionName = name;
            A = a;
            B = b;
            C = c;
            CoefficientsC = cVariants;
            Function = function;
        }
    }
}
