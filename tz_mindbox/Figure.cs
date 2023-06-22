using System;
using System.Reflection;

namespace tz_mindbox
{
    public interface IFigure
    {
        double Square();
    }

    public class Circle : IFigure
    {
        private const double pi = 3.14; 
        private double _radius;

        public double Radius
        {
            get => _radius;
            set
            {
                if (value > 0) _radius = value;
                else throw new ArgumentException("Радиус не может иметь отрицательное значение");
            }
        }
        public Circle() { }

        public Circle(params double[] arg)
        {
            if (arg.Length != 1) throw new ArgumentException("Некорректное количество аргументов. Для создания объекта класса КРУГ необходимо передать только одно значение");
            Radius = arg[0];
        }
        public double Square() => pi * Radius * Radius;
    }

    public class Triangle : IFigure
    {
        private double _sideA;
        private double _sideB;
        private double _sideC;

        public double SideA
        {
            get => _sideA;
            set
            {
                if (value > 0) _sideA = value;
                else ReturnArgumentException();
            }
        }

        public double SideB
        {
            get => _sideB;
            set
            {
                if (value > 0) _sideB = value;
                else ReturnArgumentException();
            }
        }
        public double SideC
        {
            get => _sideC;
            set
            {
                if (value > 0) _sideC = value;
                else ReturnArgumentException();
            }
        }
        public Triangle() { }

        public Triangle(params double[] arg)
        {
            if (arg.Length != 3) throw new ArgumentException("Некорректное количество аргументов. Для создания объекта класса ТРЕУГОЛЬНИК необходимо передать 3 значения");
            if (!IsExist(arg[0], arg[1], arg[2])) throw new ArgumentException("Существование треугольника с заданными сторонами невозможно");

            Array.Sort(arg, (x, y) => y.CompareTo(x));
            SideA = arg[0];
            SideB = arg[1];
            SideC = arg[2];
           
        }

        public double Square() 
        { 
            var p = (SideA + SideB + SideC)/2;
            var s = Math.Sqrt(p * (p - SideA) * (p - SideB) * (p - SideC));
            return Math.Round(s, 5);
        }

        public bool IsRightTriangle() => SideA * SideA == SideB * SideB + SideC * SideC;
        

        private bool IsExist(double a, double b, double c)
        {
            if (c + b <= a) return false;
            if (c + a <= b) return false;
            if (a + b <= c) return false;
            return true;
        }

        private void ReturnArgumentException()
        {
            throw new ArgumentException("Длина стороны треугольника не может иметь отрицательное значение");
        }
    }

    public static class SquareFinder
    {
        public static double FindSquare(Type type, params double[] arg)
        {
             if (!type.GetInterfaces().Contains(typeof(IFigure)))
                throw new ArgumentException($"Тип {type} не реализует интерфейс IFigure");
             var constructor = type.GetConstructor(new[] { typeof(double[]) });
             var figure = constructor?.Invoke(new object[] { arg });
             return (double)type
                .GetMethod("Square", BindingFlags.Instance | BindingFlags.Public)
                .Invoke(figure, null);
        }
    }
}