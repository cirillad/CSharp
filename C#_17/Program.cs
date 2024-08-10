using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace C__17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task1();
            //Task2();
            //Task3();
            Task4();
        }

        static void Task1()
        {
            string filePath = "C:/Users/Note/Desktop/test.txt";
            string fileContent = File.ReadAllText(filePath);

            var dribNumbers = Regex.Matches(fileContent, @"\d+\.\d+|\d+,\d+")
                .Cast<Match>()
                .Select(n => n.Value)
                .ToList();

            Console.WriteLine("Fractional numbers found:");

            foreach (var number in dribNumbers)
            {
                Console.WriteLine(number);
            }
        }

        static void Task2()
        {
            string filePath = "C:/Users/Note/Desktop/test.txt";
            string fileContent = File.ReadAllText(filePath);

            var numbers = Regex.Matches(fileContent, @"\d+")
                               .Cast<Match>()
                               .Select(m => int.Parse(m.Value))
                               .ToList();

            Console.WriteLine("Integer numbers found:");

            foreach (var number in numbers)
            {
                Console.WriteLine(number);
            }
        }

        static void Task3()
        {
            List<int> numbers = new List<int> { -5, 2, -1, 0, 3, 8, 6, -3 };

            var positiveNumbers = numbers.Where(n => n > 0)
                                         .OrderBy(n => n)
                                         .ToList();

            Console.WriteLine("Positive numbers in ascending order:");

            foreach (var number in positiveNumbers)
            {
                Console.WriteLine(number);
            }
        }

        static void Task4()
        {
            List<int> numbers = new List<int> { -5, 12, -1, 0, 34, 8, 15, -3, 99, 7 };

            var positiveTwoDigitNumbers = numbers.Where(n => n >= 10 && n <= 99).ToList();

            int count = positiveTwoDigitNumbers.Count();
            double average = positiveTwoDigitNumbers.Average();

            Console.WriteLine($"Count of positive two-digit numbers: {count}");
            Console.WriteLine($"Average of positive two-digit numbers: {average}");
        }
    }
}
