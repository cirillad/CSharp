class Program
{
    delegate int CalculationOperation(int[] array);
    delegate void ModificationOperation(int[] array);

    static int CountNegativeElements(int[] array)
    {
        return array.Count(n => n < 0);
    }

    static int SumOfElements(int[] array)
    {
        return array.Sum();
    }

    static int CountPrimeNumbers(int[] array)
    {
        return array.Count(IsPrime);
    }

    static bool IsPrime(int n)
    {
        if (n <= 1) return false;
        for (int i = 2; i <= Math.Sqrt(n); i++)
        {
            if (n % i == 0) return false;
        }
        return true;
    }

    static void ReplaceNegativeWithZero(int[] array)
    {
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < 0) array[i] = 0;
        }
    }

    static void SortArray(int[] array)
    {
        Array.Sort(array);
    }

    static void MoveEvenElementsToFront(int[] array)
    {
        int[] sortedArray = array.OrderBy(x => x % 2 != 0).ToArray();
        Array.Copy(sortedArray, array, array.Length);
    }

    static void Main()
    {
        int[] array = { -3, 4, -1, 7, 2, -5, 8, 0, 1, -2 };
        while (true)
        {
            Console.WriteLine("Choose operation type:");
            Console.WriteLine("1. Calculation");
            Console.WriteLine("2. Modification");
            int typeChoice = int.Parse(Console.ReadLine());

            if (typeChoice == 1)
            {
                Console.WriteLine("Choose calculation operation:");
                Console.WriteLine("1. Count negative elements");
                Console.WriteLine("2. Sum of elements");
                Console.WriteLine("3. Count prime numbers");
                int calcChoice = int.Parse(Console.ReadLine());

                CalculationOperation calcOp;

                if (calcChoice == 1)
                {
                    calcOp = CountNegativeElements;
                }
                else if (calcChoice == 2)
                {
                    calcOp = SumOfElements;
                }
                else if (calcChoice == 3)
                {
                    calcOp = CountPrimeNumbers;
                }
                else
                {
                    throw new InvalidOperationException("Invalid choice");
                }

                int result = calcOp(array);
                Console.WriteLine("Result: " + result);
            }
            else if (typeChoice == 2)
            {
                Console.WriteLine("Choose modification operation:");
                Console.WriteLine("1. Replace negative elements with 0");
                Console.WriteLine("2. Sort array");
                Console.WriteLine("3. Move even elements to the beginning");
                int modChoice = int.Parse(Console.ReadLine());

                ModificationOperation modOp;

                if (modChoice == 1)
                {
                    modOp = ReplaceNegativeWithZero;
                }
                else if (modChoice == 2)
                {
                    modOp = SortArray;
                }
                else if (modChoice == 3)
                {
                    modOp = MoveEvenElementsToFront;
                }
                else
                {
                    throw new InvalidOperationException("Invalid choice");
                }

                modOp(array);
                Console.WriteLine("Array after modification: " + string.Join(", ", array));
            }
            else
            {
                Console.WriteLine("Invalid type choice. Please try again.");
            }
        }
    }
}
