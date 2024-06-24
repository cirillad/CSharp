using System.Runtime.InteropServices;

namespace C__06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task1();
            //Task2();
            Task3();
        }

        static void Task1()
        {
            Console.WriteLine("Enter a string of digits from 0 to 9 : ");
            string str = Console.ReadLine();

            try
            {
                int number = int.Parse(str);
                Console.WriteLine($"The entered number is: {number}");
            }
            catch (FormatException)
            {

                Console.WriteLine("Error: FormatException");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Error: OverflowException");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:  {ex.Message}");
            }
        }

        static void Task2()
        {
            try
            {
                CreditCard card = new CreditCard(1234567812345678, " ", 123, new DateTime(2025, 12, 31));
                Console.WriteLine("Credit card created successfully.");
                Console.WriteLine($"Card Number: {card.CardNumber}");
                Console.WriteLine($"Card Holder: {card.PIP}");
                Console.WriteLine($"CVC: {card.CVC}");
                Console.WriteLine($"Expiry Date: {card.ExpiryDate.ToShortDateString()}");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void Task3()
        {
            Console.WriteLine("Enter a mathematical expression (only integers and * operator): ");
            string expression = Console.ReadLine();

            try
            {
                int result = EvaluateExpression(expression);
                Console.WriteLine($"The result of the expression is: {result}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Input error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }

        static int EvaluateExpression(string expression)
        {
            string[] parts = expression.Split('*');
            int result = 1;

            foreach (string part in parts)
            {
                if (!int.TryParse(part, out int number))
                {
                    throw new FormatException("The expression contains invalid characters. Only integers and * operator are allowed.");
                }
                result *= number;
            }

            return result;
        }
    }

    class CreditCard
    {   
        public double CardNumber { get; private set; }
        public string PIP { get; private set; }
        public int CVC { get; private set; }
        public DateTime ExpiryDate { get; private set; }

        public CreditCard(double cardNumber, string pip, int cvc, DateTime expiryDate)
        {
            string cardNumberStr = cardNumber.ToString();

            if (cardNumberStr.Length != 16 )
            {
                throw new ArgumentException("Invalid card number.");
            }

            CardNumber = cardNumber;

            if (string.IsNullOrWhiteSpace(pip)) 
            {
                throw new ArgumentException("Invalid card holder name.");
            }

            PIP = pip;

            if (cvc < 100 || cvc > 999)
            {
                throw new ArgumentException("Invalid CVC. CVC must be a 3-digit number.");
            }

            CVC = cvc;

            if (expiryDate <= DateTime.Now)
            {
                throw new ArgumentException("Invalid expiry date. Expiry date must be in the future.");
            }

            ExpiryDate = expiryDate;
        }
    }
}
