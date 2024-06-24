namespace C__05
{
    class Calculator
    {
        public static double Add(double a, double b)
        {
            return a + b;
        }

        public static double Sub(double a, double b)
        {
            return a - b;
        }

        public static double Mul(double a, double b)
        {
            return a * b;
        }

        public static double Div(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Division by zero is not allowed.");
            }

            return a / b;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter the first number: ");
                double num1 = double.Parse(Console.ReadLine());

                Console.Write("Enter the second number: ");
                double num2 = double.Parse(Console.ReadLine());

                Console.WriteLine("Choose the operation:");
                Console.WriteLine("1. Add");
                Console.WriteLine("2. Subtract");
                Console.WriteLine("3. Multiply");
                Console.WriteLine("4. Divide");

                Console.Write("Enter the number of the operation: ");
                int operation = int.Parse(Console.ReadLine());

                double result = 0;

                switch (operation)
                {
                    case 1:
                        result = Calculator.Add(num1, num2);
                        break;
                    case 2:
                        result = Calculator.Sub(num1, num2);
                        break;
                    case 3:
                        result = Calculator.Mul(num1, num2);
                        break;
                    case 4:
                        result = Calculator.Div(num1, num2);
                        break;
                    default:
                        throw new InvalidOperationException("Invalid operation selected.");
                }

                Console.WriteLine($"The result is: {result}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Input error: {ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Math error: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Operation error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
