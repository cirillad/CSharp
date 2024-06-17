using System.Text;

namespace C__03
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
            //Task6();
            Task7();
        }

        static void Task1()
        {
            string str = "Hello World!";
            Console.WriteLine(str);

            Console.WriteLine("Enter the string to insert : ");
            string user_string = Console.ReadLine();

            // Читати позицію для вставки від користувача
            Console.WriteLine("Enter the index to insert the string : ");
            string user_index = Console.ReadLine();

            string result_str = str.Insert(int.Parse(user_index), user_string);

            Console.WriteLine(result_str);
        }

        static void Task2()
        {
            Console.WriteLine("Write a word : ");
            
            string word = Console.ReadLine();
            string reversed_word = new string(word.Reverse().ToArray());

            if (word == reversed_word)
            {
                Console.WriteLine("It is a palindrome");
            }
            else 
            {
                Console.WriteLine("It is not a palindrome");
            }
        }

        static void Task3()
        {
            string text = "Hello World!";

            int totalLower = 0;
            int totalUpper = 0;
            int totalCount = text.Length;

            foreach (char c in text)
            {
                if (char.IsLower(c))
                {
                    totalLower++;
                }
                else if (char.IsUpper(c))
                {
                    totalUpper++;
                }
            }

            double lowerCasePercentage = (double)totalLower / totalCount * 100;
            double upperCasePercentage = (double)totalUpper / totalCount * 100;

            Console.WriteLine("Total characters: " + totalCount);
            Console.WriteLine("Lowercase letters: " + totalLower + " (" + lowerCasePercentage.ToString("0.00") + "%)");
            Console.WriteLine("Uppercase letters: " + totalUpper + " (" + upperCasePercentage.ToString("0.00") + "%)");
        }

        static void Task4()
        {
            string[] words = { "Bob", "Cherry", "Special", "Hello", "World" };
            int selectedLength = 5;

            foreach (string word in words)
            {
                Console.Write(word + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length == selectedLength)
                {
                    words[i] = words[i].Substring(0, words[i].Length - 3) + "$$$";
                }
            }

            foreach (string word in words)
            {
                Console.Write(word + " ");
            }
        }

        static void Task5()
        {
            string str = "It is a good day today";

            Console.WriteLine(str);

            Console.WriteLine("Enter The number of word you need : ");
            int num = int.Parse(Console.ReadLine());

            string[] words = str.Split(' ');

            Console.WriteLine(words[num - 1][0]);
        }

        static void Task6()
        {
            string str = "  It    is    a   good     day    today   ";

            Console.WriteLine(str);

            string[] words = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string result = string.Join("*", words);

            Console.WriteLine(result);
        }

        static void Task7() 
        {
            StringBuilder sb = new StringBuilder();
            string word;

            while (true) 
            {
                Console.WriteLine("Enter a word ( if you want to end, end the word with the period at the end ) : ");
                word = Console.ReadLine();

                if (word.EndsWith('.'))
                {
                    sb.Append(word);
                    break;
                }
                else
                {
                    sb.Append(word + ", ");
                }
            }

            Console.WriteLine("Resulting string:");
            Console.WriteLine(sb.ToString());
        }
    }
}
