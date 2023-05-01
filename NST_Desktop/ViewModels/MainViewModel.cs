using NST_Desktop.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace NST_Desktop.ViewModels
{
    /// <summary> Класс основной модели представления. </summary>
    public class MainViewModel : INotifyPropertyChanged
    {
        /// <summary> Выбранная Функция. </summary>
        private MathFunction _selectedFunction;

        /// <summary> Список строк DataGrid. </summary>
        public ObservableCollection<ResultItems> Results { get; } = new ObservableCollection<ResultItems>();

        /// <summary> Список функций. </summary>
        public ObservableCollection<MathFunction> Functions { get; } = new ObservableCollection<MathFunction>();
        
        /// <summary> Выбранная функция. </summary>
        public MathFunction SelectedFunction 
        {
            get { return _selectedFunction; }
            set 
            {
                if (_selectedFunction != value)
                {
                    _selectedFunction = value;
                    OnPropertyChanged(nameof(SelectedFunction));
                }
            } 
        }

        /// <summary> Конструктор модели представления, задающий функции и их параметры, а также подписывающий событие изменения для коллекции строк DataGrid. </summary>
        public MainViewModel()
        {
            Functions.Add(new MathFunction("Линейная", 0, 0, 1, new List<int> { 1, 2, 3, 4, 5 }, (a, b, c, x, y) => a * x + b * 1 + c));
            Functions.Add(new MathFunction("Квадратичная", 0, 0, 10, new List<int> { 10, 20, 30, 40, 50 }, (a, b, c, x, y) => a * Math.Pow(x, 2) + b * Math.Pow(y, 1) + c));
            Functions.Add(new MathFunction("Кубическая", 0, 0, 100, new List<int> { 100, 200, 300, 400, 500 }, (a, b, c, x, y) => a * Math.Pow(x, 3) + b * Math.Pow(y, 2) + c));
            Functions.Add(new MathFunction("4-ой степени", 0, 0, 1000, new List<int> { 1000, 2000, 3000, 4000, 5000 }, (a, b, c, x, y) => a * Math.Pow(x, 4) + b * Math.Pow(y, 3) + c));
            Functions.Add(new MathFunction("5-ой степени", 0, 0, 10000, new List<int> { 10000, 20000, 30000, 40000, 50000 }, (a, b, c, x, y) => a * Math.Pow(x, 5) + b * Math.Pow(y, 4) + c));

            Results.CollectionChanged += Results_Changed;
        }

        /// <summary>
        /// Является событием для изменения коллекции строк DataGrid, изменяет последнюю строку.
        /// </summary>
        /// <param name="sender"> Источник события. </param>
        /// <param name="e"> Данные события. </param>
        private void Results_Changed(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (SelectedFunction != null)
            {
                if (Results.Count > 0)
                {
                    var lastItem = Results[Results.Count - 1];
                    lastItem.UpdateResult(SelectedFunction);
                }
            }
        }

        /// <summary> Определяет событие INotifyPropertyChanged. </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Обновляет элементы пользовательского интерфейса.
        /// </summary>
        /// <param name="propertyName"> Имя обновляемого элемента. </param>
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
