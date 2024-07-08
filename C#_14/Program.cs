namespace C__14
{
    public class Stack<T>
    {
        private T[] items;
        private int top;

        public Stack(int capacity)
        {
            items = new T[capacity];
            top = -1;
        }

        public void Push(T item)
        {
            if (top == items.Length - 1)
            {
                Console.WriteLine("Stack Overflow");
                return;
            }

            items[++top] = item;
        }

        public T Pop()
        {
            if (top == -1)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return items[top--];
        }

        public T Peek()
        {
            if (top == -1)
            {
                throw new InvalidOperationException("Stack is empty");
            }

            return items[top];
        }

        public int Count
        {
            get { return top + 1; }
        }
    }

    public class Queue<T>
    {
        private LinkedList<T> items;

        public Queue()
        {
            items = new LinkedList<T>();
        }

        public void Enqueue(T item)
        {
            items.AddLast(item);
        }

        public T Dequeue()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            T item = items.First.Value;
            items.RemoveFirst();
            return item;
        }

        public T Peek()
        {
            if (items.Count == 0)
            {
                throw new InvalidOperationException("Queue is empty");
            }

            return items.First.Value;
        }

        public int Count
        {
            get { return items.Count; }
        }
    }

    internal class Program
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
            int maxInt = Max(3, 1, 2);
            Console.WriteLine($"Max int: {maxInt}");

            double maxDouble = Max(1.1, 3.3, 2.2);
            Console.WriteLine($"Max double: {maxDouble}");

            string maxString = Max("apple", "banana", "cherry");
            Console.WriteLine($"Max string: {maxString}");
        }

        static void Task2()
        {
            int maxInt = Min(3, 1, 2);
            Console.WriteLine($"Max int: {maxInt}");

            double maxDouble = Min(1.1, 3.3, 2.2);
            Console.WriteLine($"Max double: {maxDouble}");

            string maxString = Min("apple", "banana", "cherry");
            Console.WriteLine($"Max string: {maxString}");
        }

        static void Task3()
        {
            int[] intArray = { 1, 2, 3, 4, 5 };
            double[] doubleArray = { 1.1, 2.2, 3.3, 4.4, 5.5 };
            decimal[] decimalArray = { 1.1m, 2.2m, 3.3m, 4.4m, 5.5m };

            Console.WriteLine($"Sum of int array: {Sum(intArray)}");
            Console.WriteLine($"Sum of double array: {Sum(doubleArray)}");
            Console.WriteLine($"Sum of decimal array: {Sum(decimalArray)}");
        }

        static void Task4()
        {
            Stack<int> stack = new Stack<int>(5);

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine($"Count: {stack.Count}");

            Console.WriteLine($"Top element: {stack.Peek()}");

            Console.WriteLine("Pop elements:");
            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }

            Console.WriteLine($"Count after popping all elements: {stack.Count}");
        }

        static void Task5()
        {
            Queue<int> queue = new Queue<int>();

            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);

            Console.WriteLine($"Count: {queue.Count}");

            Console.WriteLine($"Front element: {queue.Peek()}");

            Console.WriteLine("Dequeue elements:");
            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }

            Console.WriteLine($"Count after dequeuing all elements: {queue.Count}");
        }


        public static T Max<T>(T a, T b, T c) where T : IComparable<T>
        {
            T max = a;

            if (b.CompareTo(max) > 0)
            {
                max = b;
            }

            if (c.CompareTo(max) > 0)
            {
                max = c;
            }

            return max;
        }

        public static T Min<T>(T a, T b, T c) where T : IComparable<T>
        {
            T max = a;

            if (b.CompareTo(max) < 0)
            {
                max = b;
            }

            if (c.CompareTo(max) < 0)
            {
                max = c;
            }

            return max;
        }

        public static T Sum<T>(T[] arr) where T : IComparable<T>
        {
            dynamic sum = 0;

            foreach (var item in arr)
            {
                sum += item;
            }

            return sum;
        }
    }
}
