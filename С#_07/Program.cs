namespace С__07
{
    public class Square
    {
        private double a;

        public double A
        {
            get { return a; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("The length of the side of the ійгфку must be a positive number.");

                a = value;
            }
        }

        public Square()
        {
            A = 1;
        }

        public Square(double a)
        {
            A = a;
        }

        public override string ToString()
        {
            return $"Square: Side length = {A}";
        }

        public override bool Equals(object? obj)
        {
            return obj is Square square &&
                   A == square.A;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(A);
        }

        public static Square operator -(Square s)
        {
            Square res = new Square() { A = s.A * -1 };

            return res;
        }

        public static Square operator ++(Square s)
        {
            s.A++;
            return s;
        }

        public static Square operator --(Square s)
        {
            s.A++;
            return s;
        }

        public static Square operator +(Square s1, Square s2)
        {
            Square res = new Square() { A = s1.A + s2.A };

            return res;
        }

        public static Square operator -(Square s1, Square s2)
        {
            Square res = new Square() { A = s1.A - s2.A };

            return res;
        }

        public static Square operator *(Square s1, Square s2)
        {
            Square res = new Square() { A = s1.A * s2.A };

            return res;
        }

        public static Square operator /(Square s1, Square s2)
        {
            Square res = new Square() { A = s1.A / s2.A };

            return res;
        }

        public static bool operator ==(Square s1, Square s2)
        {
            return s1.Equals(s2);
        }
        
        public static bool operator !=(Square p1, Square p2)
        {
            return !(p1 == p2);
        }

        public static bool operator <(Square s1, Square s2)
        {
            return s1.A < s2.A;
        }

        public static bool operator >(Square s1, Square s2)
        {
            return s1.A > s2.A;
        }

        public static bool operator <=(Square s1, Square s2)
        {
            return s1.A <= s2.A;
        }

        public static bool operator >=(Square s1, Square s2)
        {
            return s1.A >= s2.A;
        }

        public static implicit operator int(Square s1)
        {
            return (int)s1.A;
        }

        public static explicit operator Rectangle(Square s)
        {
            return new Rectangle(s.A, s.A);
        }

        public static bool operator true(Square s)
        {
            return s.A != 0;
        }

        public static bool operator false(Square s)
        {
            return s.A == 0;
        }
    }

    public class Rectangle
    {
        private double a;
        private double b;

        public double A
        {
            get { return a; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("The length of the sides of the rectangle must be a positive number.");

                a = value;
            }
        }

        public double B
        {
            get { return b; }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("The length of the sides of the rectangle must be a positive number.");

                b = value;
            }
        }

        public Rectangle()
        {
            A = 1;
            B = 1;
        }

        public Rectangle(double a, double b)
        {
            A = a;
            B = b;
        }

        public override bool Equals(object? obj)
        {
            return obj is Rectangle rectangle &&
                   A == rectangle.a &&
                   B == rectangle.b;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(A, B);
        }

        public override string ToString()
        {
            return $"Rectangle: Side A = {A}, Side B = {B}";
        }

        public static Rectangle operator ++(Rectangle rectangle)
        {
            rectangle.A++;
            rectangle.B++;
            return rectangle;
        }

        public static Rectangle operator --(Rectangle rectangle)
        {
            rectangle.A--;
            rectangle.B--;
            return rectangle;
        }

        public static Rectangle operator +(Rectangle rect1, Rectangle rect2)
        {
            return new Rectangle(rect1.A + rect2.A, rect1.B + rect2.B);
        }

        public static Rectangle operator -(Rectangle rect1, Rectangle rect2)
        {
            double newA = rect1.A - rect2.A;
            double newB = rect1.B - rect2.B;

            if (newA <= 0) newA = 1;
            if (newB <= 0) newB = 1;

            return new Rectangle(newA, newB);
        }

        public static Rectangle operator *(Rectangle rect1, Rectangle rect2)
        {
            return new Rectangle(rect1.A * rect2.A, rect1.B * rect2.B);
        }

        public static Rectangle operator /(Rectangle rect1, Rectangle rect2)
        {
            return new Rectangle(rect1.A / rect2.A, rect1.B / rect2.B);
        }

        public static bool operator <(Rectangle rect1, Rectangle rect2)
        {
            return rect1.A * rect1.B < rect2.A * rect2.B;
        }

        public static bool operator >(Rectangle rect1, Rectangle rect2)
        {
            return rect1.A * rect1.B > rect2.A * rect2.B;
        }

        public static bool operator <=(Rectangle rect1, Rectangle rect2)
        {
            return rect1.A * rect1.B <= rect2.A * rect2.B;
        }

        public static bool operator >=(Rectangle rect1, Rectangle rect2)
        {
            return rect1.A * rect1.B >= rect2.A * rect2.B;
        }

        public static bool operator ==(Rectangle rect1, Rectangle rect2)
        {
            return rect1.Equals(rect2);
        }

        public static bool operator !=(Rectangle rect1, Rectangle rect2)
        {
            return !(rect1 == rect2);
        }

        public static explicit operator int(Rectangle rect)
        {
            return (int)(rect.A * rect.B);
        }

        public static bool operator true(Rectangle rect)
        {
            return rect.A != 0 && rect.B != 0;
        }

        public static bool operator false(Rectangle rect)
        {
            return rect.A == 0 || rect.B == 0;
        }

        public static explicit operator Square(Rectangle r)
        {
            return new Square(Math.Min(r.A, r.B));
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Square sq1 = new Square(5);
            Square sq2 = new Square(3);
            Rectangle rect1 = new Rectangle(2, 4);
            Rectangle rect2 = new Rectangle(3, 5);

            Console.WriteLine("Squares:");
            Console.WriteLine(sq1);
            Console.WriteLine(sq2);

            Square sqSum = sq1 + sq2;
            Console.WriteLine($"Sum of squares: {sqSum}");

            Square sqDiff = sq1 - sq2;
            Console.WriteLine($"Difference of squares: {sqDiff}");

            Square sqProd = sq1 * sq2;
            Console.WriteLine($"Product of squares: {sqProd}");

            Square sqQuot = sq1 / sq2;
            Console.WriteLine($"Quotient of squares: {sqQuot}");

            Console.WriteLine("\nRectangles:");
            Console.WriteLine(rect1);
            Console.WriteLine(rect2);

            Rectangle rectSum = rect1 + rect2;
            Console.WriteLine($"Sum of rectangles: {rectSum}");

            Rectangle rectDiff = rect1 - rect2;
            Console.WriteLine($"Difference of rectangles: {rectDiff}");

            Rectangle rectProd = rect1 * rect2;
            Console.WriteLine($"Product of rectangles: {rectProd}");

            Rectangle rectQuot = rect1 / rect2;
            Console.WriteLine($"Quotient of rectangles: {rectQuot}");

            // Перетворення типів
            Rectangle rectFromSquare = (Rectangle)sq1;
            Console.WriteLine($"\nRectangle from square: {rectFromSquare}");

            Square squareFromRect = (Square)rect1;
            Console.WriteLine($"Square from rectangle: {squareFromRect}");

            int intFromSquare = sq1;
            Console.WriteLine($"Integer from square: {intFromSquare}");

            int intFromRect = (int)rect1;
            Console.WriteLine($"Integer from rectangle: {intFromRect}");

            // Оператори порівняння
            Console.WriteLine("\nComparison:");
            Console.WriteLine($"sq1 == sq2: {sq1 == sq2}");
            Console.WriteLine($"sq1 != sq2: {sq1 != sq2}");
            Console.WriteLine($"sq1 > sq2: {sq1 > sq2}");
            Console.WriteLine($"sq1 < sq2: {sq1 < sq2}");
            Console.WriteLine($"rect1 == rect2: {rect1 == rect2}");
            Console.WriteLine($"rect1 != rect2: {rect1 != rect2}");
            Console.WriteLine($"rect1 > rect2: {rect1 > rect2}");
            Console.WriteLine($"rect1 < rect2: {rect1 < rect2}");

            // Оператори true/false
            Console.WriteLine("\nTrue/False:");
            if (sq1)
                Console.WriteLine("sq1 is true.");
            else
                Console.WriteLine("sq1 is false.");

            if (rect1)
                Console.WriteLine("rect1 is true.");
            else
                Console.WriteLine("rect1 is false.");
        }
    }
}
