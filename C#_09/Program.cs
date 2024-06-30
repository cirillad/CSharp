namespace C__08
{
    interface IOutput
    {
        void Show();
        void Show(string info);
    }

    interface IMath
    {
        int Max();
        int Min();
        float Avg();
        bool Search(int valueToSearch);
    }

    interface ISort
    {
        void SortAsc();
        void SortDesc();
        void SortByParam(bool isAsc);
    }

    class Array : IOutput, IMath, ISort
    {
        private int[] _arr;

        public Array()
        {
            _arr = new int[0];
        }

        public Array(int[] arr)
        {
            _arr = arr;
        }

        public void Show()
        {
            foreach (int i in _arr)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
        }

        public void Show(string info)
        {
            Console.WriteLine(info);
            Show();
        }

        public int Max()
        {
            return _arr.Max();
        }

        public int Min()
        {
            return _arr.Min();
        }

        public float Avg()
        {
            return (float)_arr.Average();
        }

        public bool Search(int valueToSearch)
        {
            return _arr.Contains(valueToSearch);
        }

        public void SortAsc()
        {
            System.Array.Sort(_arr);
        }

        public void SortDesc()
        {
            System.Array.Sort(_arr);
            System.Array.Reverse(_arr);
        }

        public void SortByParam(bool isAsc)
        {
            if (isAsc)
            {
                SortAsc();
            }
            else
            {
                SortDesc();
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Task1();
        }

        static void Task1()
        {
            int[] nums = { 5, 2, 9, 1, 5, 6 };

            Array arr1 = new Array(nums);

            Console.WriteLine("Task 1");
            Console.WriteLine();

            Console.WriteLine("Example 1");
            arr1.Show();

            Console.WriteLine("Example 2");
            arr1.Show("My array: ");

            Console.WriteLine("Task 2");
            Console.WriteLine();

            Console.WriteLine("Max: " + arr1.Max());
            Console.WriteLine("Min: " + arr1.Min());
            Console.WriteLine("Avg: " + arr1.Avg());
            Console.WriteLine("Search for 3: " + arr1.Search(3));
            Console.WriteLine("Search for 5: " + arr1.Search(5));
            Console.WriteLine();

            Console.WriteLine("Task 3");
            Console.WriteLine();

            Console.WriteLine("Array sorted in ascending order:");
            arr1.SortAsc();
            arr1.Show();

            Console.WriteLine("Array sorted in descending order:");
            arr1.SortDesc();
            arr1.Show();

            Console.WriteLine("Array sorted by parameter (true for ascending):");
            arr1.SortByParam(true);
            arr1.Show();

            Console.WriteLine("Array sorted by parameter (false for descending):");
            arr1.SortByParam(false);
            arr1.Show();
        }
    }
}
