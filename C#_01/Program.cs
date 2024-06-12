using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task1();
            //Task2();
            //Task3();
            //Task4();
            //Task5();
            Task6();
        }

        static void Task1()
        {
            Console.WriteLine(@"It's easy to win forgiveness for being wrong; 
being right is what gets you into real trouble.
Bjarne Stroustrup");
        }

        static void Task2()
        {
            Console.WriteLine("Enter first number : ");
            int num1 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter second number : ");
            int num2 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter third number : ");
            int num3 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter fourth number : ");
            int num4 = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter fifth number : ");
            int num5 = int.Parse(Console.ReadLine());

            int SumOfNums = num1 + num2 + num3 + num4 + num5;
            Console.WriteLine("Sum : " + SumOfNums);

            int MultiOfNums = num1 * num2 * num3 * num4 * num5;
            Console.WriteLine("Multiply : " + MultiOfNums);

            int max = num1;

            if (num2 > max)
            {
                max = num2;
            }

            if (num3 > max)
            {
                max = num3;
            }

            if (num4 > max)
            {
                max = num4;
            }

            if (num5 > max)
            {
                max = num5;
            }

            int min = num1;

            if (num2 < min)
            {
                min = num2;
            }

            if (num3 < min)
            {
                min = num3;
            }

            if (num4 < min)
            {
                min = num4;
            }

            if (num5 < min)
            {
                min = num5;
            }

            Console.WriteLine("Max : " + max);
            Console.WriteLine("Min : " + min);
        }

        static void Task3()
        {
            Console.WriteLine("Enter 6-digit number : ");
            int num = int.Parse(Console.ReadLine());

            string strNum = num.ToString();

            for (int i = 5; i >= 0; i--)
            {
                Console.Write(strNum[i]);
            }

            Console.WriteLine();
        }

        static void Task4()
        {
            Console.WriteLine("Enter first number : ");
            int startNum = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter second number : ");
            int finishNum = int.Parse(Console.ReadLine());

            int a = 0;
            int b = 1;

            while (a <= finishNum) 
            {
                if (a >= startNum)
                {
                    Console.Write(a + " ");
                }

                int nextNum = a + b;
                a = b;
                b = nextNum;
            }

            Console.WriteLine();
        }

        static void Task5()
        {
            Console.WriteLine("Enter the first num : ");
            int firstNum = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the second num (it must be bigger then first num) : ");
            int secondNum = int.Parse(Console.ReadLine());

            if (firstNum > secondNum) 
            {
                Console.WriteLine("ERROR");
                return;
            }
            else
            {
                for (int i = firstNum; i <= secondNum; i++) 
                {
                    for(int j = i; j < i + i; j++)
                    {
                        Console.Write(i);
                    }

                    Console.WriteLine();
                }
            }
        }

        static void Task6()
        {
            Console.WriteLine("Enter the length of line : ");
            int lenOfLine = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the char of line : ");
            char charOfLine = char.Parse(Console.ReadLine());

            Console.WriteLine("Enter the diraction of line (1 - horizontal, 2 - vertical) : ");
            int directionOfLine = int.Parse(Console.ReadLine());

            if(directionOfLine == 1)
            {
                for (int i = 0; i < lenOfLine; i++)
                {
                    Console.Write(charOfLine);
                }

                Console.WriteLine();
            }
            else if(directionOfLine == 2)
            {
                for (int i = 0; i < lenOfLine; i++)
                {
                    Console.WriteLine(charOfLine);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("ERROR");
            }
        }
    }
}
