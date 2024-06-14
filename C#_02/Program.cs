using System;

namespace MyNamespace
{
    class Program
    {
        static void Main(string[] args)
        {
            //Task1();
            //Task2();
            //Task3();
            //Task4();
            Task5();
        }

        static void Task1()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1, 1, 1 };

            ShowArr(arr);
            Console.WriteLine("Even : " + FindEvenNums(arr));
            Console.WriteLine("Odd : " + FindOddNums(arr));
            Console.WriteLine("Unique : ");
            FindUniqueValues(arr);

        }

        static void Task2()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 1 };

            int num = int.Parse(Console.ReadLine());

            FindLessThen(arr, num);
        }

        static void Task3()
        {
            int[] A = new int[5];
            double[,] B = new double[3, 4];

            Console.WriteLine("Initialization of one-dimensional array : ");
            for (int i = 0; i < A.Length; i++)
            {
                A[i] = int.Parse(Console.ReadLine());
            }

            Random random = new Random();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    double res = random.NextDouble() * 100;
                    res = Math.Round(res, 2);
                    B[i, j] = res;
                }
            }

            Console.WriteLine("\nOne-dimensional array:");
            foreach (int i in A) 
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();

            Console.WriteLine("\nTwo-dimensional array:");
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write(B[i, j] + "\t");
                }
                Console.WriteLine();
            }

            int minA = A.Min();
            int maxA = A.Max();

            double maxB = B[0, 0];
            double minB = B[0, 0];

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (B[i, j] > maxB)
                        maxB = B[i, j];

                    if (B[i, j] < minB)
                        minB = B[i, j];
                }
            }

            Console.WriteLine();

            Console.WriteLine($"Max A: {maxA}");
            Console.WriteLine($"Min A: {minA}");
            Console.WriteLine($"Max B: {maxB}");
            Console.WriteLine($"Min B: {minB}");

            int sumA = A.Sum();
            int productA = 1;

            foreach (var item in A)
            {
                productA *= item;
            }

            double sumB = 0;
            double productB = 1;
            
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    sumB += B[i, j];
                    productB *= B[i, j];
                }
            }

            Console.WriteLine();

            Console.WriteLine($"Sum A: {sumA}");
            Console.WriteLine($"Product B: {productA}");
            Console.WriteLine($"Sum B: {sumB}");
            Console.WriteLine($"Product B: {productB}");

            int sumEvenA = 0;

            foreach (var item in A)
            {
                if (item % 2 == 0)
                {
                    sumEvenA += item;
                }
            }

            Console.WriteLine();
            Console.WriteLine($"Sum of even A: {sumEvenA}");

            double sumOddColumnsB = 0;

            for (int j = 0; j < 4; j += 2)
            {
                for (int i = 0; i < 3; i++)
                {
                    sumOddColumnsB += B[i, j];
                }
            }

            Console.WriteLine($"Sum of odd B: {sumOddColumnsB}");

            Console.ReadLine();
        }

        static void Task4()
        {
            int[,] arr = new int[5, 5];
            Random random = new Random();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arr[i, j] = random.Next(-100, 100);
                }
            }

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }

                Console.WriteLine();
            }
        }

        static void Task5()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 6, 7, 8, 9, 10, 1, 1, 1 };

            int minArrValue = arr.Min();
            int count = 0;

            for (int i = 0;i < arr.Length; i++) 
            {
                if (arr[i] == minArrValue + 5)
                {
                    count++;
                }
            }

            Console.WriteLine(count);
        }

        static void ShowArr(int[] arr) 
        {
            for (int i = 0; i < arr.Length; i++) 
            {
                Console.Write(arr[i] + " ");
            }

            Console.WriteLine();
        }
        static int FindEvenNums(int[] arr)
        {
            int count = 0;

            for(int i = 0;i < arr.Length; i++) 
            {
                if (arr[i] % 2 == 0)
                {
                    count++;
                }
            }

            return count;
        }

        static int FindOddNums(int[] arr)
        {
            int count = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0)
                {
                    count++;
                }
            }

            return count;
        }

        static void FindUniqueValues(int[] arr)
        {
            HashSet<int> uniqueSet = new HashSet<int>(); // трохи зхитрив

            for (int i = 0; i < arr.Length; i++)
            {
                uniqueSet.Add(arr[i]);
            }

            foreach (int i in uniqueSet)
            {
                Console.Write(i + " ");
            }

            Console.WriteLine();
        }

        static void FindLessThen(int[] arr, int num) 
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < num)
                {
                    Console.Write(arr[i] + " ");
                }
            }
           
            Console.WriteLine();
        }
    }
}

