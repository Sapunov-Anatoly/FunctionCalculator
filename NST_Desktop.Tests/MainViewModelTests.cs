using Microsoft.VisualStudio.TestTools.UnitTesting;
using NST_Desktop.Models;
using System.Collections.Generic;
using System;

namespace NST_Desktop.Tests
{
    [TestClass]
    public class MainViewModelTests
    {
        [TestMethod]
        public void LinearFunction_TestValidValues()
        {
            // arrange
            var function = new MathFunction("Линейная", 0, 0, 1, new List<int> { 1, 2, 3, 4, 5 }, (a, b, c, x, y) => a * x + b * 1 + c);
            
            double _a = 2.241;
            double _b = 1.9498;
            int _c = 4;
            double _x = 0.946;
            double _y = 24.123;

            double expected = _a * _x + _b * 1 + _c; 

            // act
            double result = function.Function(_a, _b, _c, _x, _y);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void QadraticFunction_TestValidValues()
        {
            // arrange
            var function = new MathFunction("Квадратичная", 0, 0, 10, new List<int> { 10, 20, 30, 40, 50 }, (a, b, c, x, y) => a * Math.Pow(x, 2) + b * Math.Pow(y, 1) + c);

            double _a = 2.241;
            double _b = 1.9498;
            int _c = 4;
            double _x = 0.946;
            double _y = 24.123;

            double expected = _a * Math.Pow(_x, 2) + _b * Math.Pow(_y, 1) + _c; 

            // act
            double result = function.Function(_a, _b, _c, _x, _y);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CubicFunction_TestValidValues()
        {
            // arrange
            var function = new MathFunction("Кубическая", 0, 0, 100, new List<int> { 100, 200, 300, 400, 500 }, (a, b, c, x, y) => a * Math.Pow(x, 3) + b * Math.Pow(y, 2) + c);

            double _a = 2.241;
            double _b = 1.9498;
            int _c = 4;
            double _x = 0.946;
            double _y = 24.123;

            double expected = _a * Math.Pow(_x, 3) + _b * Math.Pow(_y, 2) + _c;

            // act
            double result = function.Function(_a, _b, _c, _x, _y);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FourthExtentFunction_TestValidValues()
        {
            // arrange
            var function = new MathFunction("4-ой степени", 0, 0, 1000, new List<int> { 1000, 2000, 3000, 4000, 5000 }, (a, b, c, x, y) => a * Math.Pow(x, 4) + b * Math.Pow(y, 3) + c);

            double _a = 2.241;
            double _b = 1.9498;
            int _c = 4;
            double _x = 0.946;
            double _y = 24.123;

            double expected = _a * Math.Pow(_x, 4) + _b * Math.Pow(_y, 3) + _c; 

            // act
            double result = function.Function(_a, _b, _c, _x, _y);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FifthExtentFunction_TestValidValues()
        {
            // arrange
            var function = new MathFunction("5-ой степени", 0, 0, 10000, new List<int> { 10000, 20000, 30000, 40000, 50000 }, (a, b, c, x, y) => a * Math.Pow(x, 5) + b * Math.Pow(y, 4) + c);

            double _a = 2.241;
            double _b = 1.9498;
            int _c = 4;
            double _x = 0.946;
            double _y = 24.123;

            double expected = _a * Math.Pow(_x, 5) + _b * Math.Pow(_y, 4) + _c;

            // act
            double result = function.Function(_a, _b, _c, _x, _y);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void LinearFunction_TestZeroX()
        {
            // arrange
            var function = new MathFunction("Линейная", 0, 0, 1, new List<int> { 1, 2, 3, 4, 5 }, (a, b, c, x, y) => a * x + b * 1 + c);

            double _a = 2.241;
            double _b = 1.9498;
            int _c = 4;
            double _x = 0;
            double _y = 24.123;

            double expected = _a * _x + _b * 1 + _c;

            // act
            double result = function.Function(_a, _b, _c, _x, _y);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void QadraticFunction_TestZeroX()
        {
            // arrange
            var function = new MathFunction("Квадратичная", 0, 0, 10, new List<int> { 10, 20, 30, 40, 50 }, (a, b, c, x, y) => a * Math.Pow(x, 2) + b * Math.Pow(y, 1) + c);

            double _a = 2.241;
            double _b = 1.9498;
            int _c = 4;
            double _x = 0;
            double _y = 24.123;

            double expected = _a * Math.Pow(_x, 2) + _b * Math.Pow(_y, 1) + _c;

            // act
            double result = function.Function(_a, _b, _c, _x, _y);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void CubicFunction_TestZeroX()
        {
            // arrange
            var function = new MathFunction("Кубическая", 0, 0, 100, new List<int> { 100, 200, 300, 400, 500 }, (a, b, c, x, y) => a * Math.Pow(x, 3) + b * Math.Pow(y, 2) + c);

            double _a = 2.241;
            double _b = 1.9498;
            int _c = 4;
            double _x = 0;
            double _y = 24.123;

            double expected = _a * Math.Pow(_x, 3) + _b * Math.Pow(_y, 2) + _c;

            // act
            double result = function.Function(_a, _b, _c, _x, _y);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FourthExtentFunction_TestZeroX()
        {
            // arrange
            var function = new MathFunction("4-ой степени", 0, 0, 1000, new List<int> { 1000, 2000, 3000, 4000, 5000 }, (a, b, c, x, y) => a * Math.Pow(x, 4) + b * Math.Pow(y, 3) + c);

            double _a = 2.241;
            double _b = 1.9498;
            int _c = 4;
            double _x = 0;
            double _y = 24.123;

            double expected = _a * Math.Pow(_x, 4) + _b * Math.Pow(_y, 3) + _c;

            // act
            double result = function.Function(_a, _b, _c, _x, _y);

            // assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void FifthExtentFunction_TestZeroX()
        {
            // arrange
            var function = new MathFunction("5-ой степени", 0, 0, 10000, new List<int> { 10000, 20000, 30000, 40000, 50000 }, (a, b, c, x, y) => a * Math.Pow(x, 5) + b * Math.Pow(y, 4) + c);

            double _a = 2.241;
            double _b = 1.9498;
            int _c = 4;
            double _x = 0;
            double _y = 24.123;

            double expected = _a * Math.Pow(_x, 5) + _b * Math.Pow(_y, 4) + _c;

            // act
            double result = function.Function(_a, _b, _c, _x, _y);

            // assert
            Assert.AreEqual(expected, result);
        }
    }
}
