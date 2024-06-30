using System;

namespace С__07
{
    abstract class GeometricFigure
    {
        public abstract double GetArea();
        public abstract double GetPerimeter();
    }

    class Triangle : GeometricFigure
    {
        private double _a, _b, _c;

        public Triangle(double a, double b, double c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        public override double GetArea()
        {
            double s = (_a + _b + _c) / 2;
            return Math.Sqrt(s * (s - _a) * (s - _b) * (s - _c));
        }

        public override double GetPerimeter()
        {
            return _a + _b + _c;
        }
    }

    class Square : GeometricFigure
    {
        private double _side;

        public Square(double side)
        {
            _side = side;
        }

        public override double GetArea()
        {
            return _side * _side;
        }

        public override double GetPerimeter()
        {
            return 4 * _side;
        }
    }

    class Rhombus : GeometricFigure
    {
        private double _side, _diagonal1, _diagonal2;

        public Rhombus(double side, double diagonal1, double diagonal2)
        {
            _side = side;
            _diagonal1 = diagonal1;
            _diagonal2 = diagonal2;
        }

        public override double GetArea()
        {
            return (_diagonal1 * _diagonal2) / 2;
        }

        public override double GetPerimeter()
        {
            return 4 * _side;
        }
    }

    class Rectangle : GeometricFigure
    {
        private double _length, _width;

        public Rectangle(double length, double width)
        {
            _length = length;
            _width = width;
        }

        public override double GetArea()
        {
            return _length * _width;
        }

        public override double GetPerimeter()
        {
            return 2 * (_length + _width);
        }
    }

    class Parallelogram : GeometricFigure
    {
        private double _base, _side, _height;

        public Parallelogram(double baseLength, double side, double height)
        {
            _base = baseLength;
            _side = side;
            _height = height;
        }

        public override double GetArea()
        {
            return _base * _height;
        }

        public override double GetPerimeter()
        {
            return 2 * (_base + _side);
        }
    }

    class Trapezoid : GeometricFigure
    {
        private double _a, _b, _c, _d, _height;

        public Trapezoid(double a, double b, double c, double d, double height)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
            _height = height;
        }

        public override double GetArea()
        {
            return ((_a + _b) / 2) * _height;
        }

        public override double GetPerimeter()
        {
            return _a + _b + _c + _d;
        }
    }

    class Circle : GeometricFigure
    {
        private double _radius;

        public Circle(double radius)
        {
            _radius = radius;
        }

        public override double GetArea()
        {
            return Math.PI * _radius * _radius;
        }

        public override double GetPerimeter()
        {
            return 2 * Math.PI * _radius;
        }
    }

    class Ellipse : GeometricFigure
    {
        private double _majorAxis, _minorAxis;

        public Ellipse(double majorAxis, double minorAxis)
        {
            _majorAxis = majorAxis;
            _minorAxis = minorAxis;
        }

        public override double GetArea()
        {
            return Math.PI * _majorAxis * _minorAxis;
        }

        public override double GetPerimeter()
        {
            return Math.PI * (3 * (_majorAxis + _minorAxis) - Math.Sqrt((3 * _majorAxis + _minorAxis) * (_majorAxis + 3 * _minorAxis)));
        }
    }

    class CompositeFigure : GeometricFigure
    {
        private List<GeometricFigure> _figures;

        public CompositeFigure(params GeometricFigure[] figures)
        {
            _figures = new List<GeometricFigure>(figures);
        }

        public override double GetArea()
        {
            double totalArea = 0;
            foreach (var figure in _figures)
            {
                totalArea += figure.GetArea();
            }
            return totalArea;
        }

        public override double GetPerimeter()
        {
            double totalPerimeter = 0;
            foreach (var figure in _figures)
            {
                totalPerimeter += figure.GetPerimeter();
            }
            return totalPerimeter;
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            var triangle = new Triangle(3, 3, 3);
            var square = new Square(3);
            var circle = new Circle(3);

            var compositeFigure = new CompositeFigure(triangle, square, circle);

            Console.WriteLine("Total area : " + compositeFigure.GetArea());
            Console.WriteLine("Total perimeter : " + compositeFigure.GetPerimeter());
        }
    }
}
