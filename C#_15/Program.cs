using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace C__15._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Task1();
            //Task2();
            //Task3();
            //Task5();
            Task6();
        }

        static void Task1()
        {
            Console.Write("Enter the path to the file: ");
            string path = Console.ReadLine();

            DisplayFile(path);
        }

        static void Task2()
        {
            Console.Write("Choose an option:\n1. Enter array values manually\n2. Load array from file\n");
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    EnterArrayAndSaveToFile();
                    break;
                case 2:
                    Console.Write("Enter the path to file : ");
                    string path = Console.ReadLine();
                    LoadArrayFromFile(path);
                    break;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }

        static void Task3()
        {
            Random random = new Random();

            int[] numbers = new int[10000];
            for (int i = 0; i < 10000; i++)
            {
                numbers[i] = random.Next(1, 1001);
            }

            string evenFilePath = "even_numbers.txt";
            string oddFilePath = "odd_numbers.txt";

            SeparateAndSaveNumbers(numbers, evenFilePath, oddFilePath);

            DisplayStatistics(numbers);
        }

        static void Task5()
        {
            Console.WriteLine("Enter the path to file : ");
            string path = Console.ReadLine();

            Console.WriteLine("Enter a word : ");
            string word = Console.ReadLine();

            SearchWordInFile(path, word);
            SearchWordsInFile(path, word); // ця функція не працює, не розумію що не так
            SearchWordReverseInFile(path, word);
        }

        static void Task6()
        {
            Console.Write("Enter the path to the file: ");
            string filePath = Console.ReadLine();

            if (File.Exists(filePath))
            {
                DisplayFileStatistics(filePath);
            }
            else
            {
                Console.WriteLine("Error: File does not exist.");
            }
        }

        static void DisplayFile(string path) 
        {
            if (File.Exists(path)) 
            {
                Console.WriteLine("File content : ");
                Console.WriteLine(File.ReadAllText(path));
            }
            else
            {
                Console.WriteLine("Error: File does not exist.");
            }
        }

        static void SaveArrayToFile(int[] arr, string filePath)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    foreach (int element in arr)
                    {
                        writer.WriteLine(element);
                    }
                }
                Console.WriteLine("Array content successfully saved to file.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while saving the file:");
                Console.WriteLine(ex.Message);
            }
        }

        static int[] LoadArrayFromFile(string filePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                int[] array = new int[lines.Length];

                for (int i = 0; i < lines.Length; i++)
                {
                    if (int.TryParse(lines[i], out int value))
                    {
                        array[i] = value;
                    }
                    else
                    {
                        Console.WriteLine($"Invalid value at line {i + 1}. Skipping.");
                    }
                }

                Console.WriteLine("Array loaded successfully from file.");
                return array;
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while loading the file:");
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        static void EnterArrayAndSaveToFile()
        {
            Console.Write("Enter the number of elements in the array: ");
            int arraySize = int.Parse(Console.ReadLine());

            int[] array = new int[arraySize];

            for (int i = 0; i < arraySize; i++)
            {
                Console.Write($"Enter element {i + 1}: ");
                array[i] = int.Parse(Console.ReadLine());
            }

            Console.Write("Enter the path to the file to save the array content: ");
            string filePath = Console.ReadLine();

            SaveArrayToFile(array, filePath);
        }

        static void SeparateAndSaveNumbers(int[] numbers, string evenFilePath, string oddFilePath)
        {
            try
            {
                using (StreamWriter evenWriter = new StreamWriter(evenFilePath))
                using (StreamWriter oddWriter = new StreamWriter(oddFilePath))
                {
                    foreach (int number in numbers)
                    {
                        if (number % 2 == 0)
                        {
                            evenWriter.WriteLine(number);
                        }
                        else
                        {
                            oddWriter.WriteLine(number);
                        }
                    }
                }
                Console.WriteLine("Numbers separated and saved to files successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while saving files:");
                Console.WriteLine(ex.Message);
            }
        }

        static void DisplayStatistics(int[] numbers)
        {
            int evenCount = 0;
            int oddCount = 0;

            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    evenCount++;
                }
                else
                {
                    oddCount++;
                }
            }

            Console.WriteLine($"Total numbers: {numbers.Length}");
            Console.WriteLine($"Even numbers: {evenCount}");
            Console.WriteLine($"Odd numbers: {oddCount}");
        }

        static void SearchWordInFile(string filePath, string word)
        {
            try
            {
                string fileContent = File.ReadAllText(filePath);
                bool found = fileContent.Contains(word);

                if (found)
                {
                    Console.WriteLine($"The word '{word}' is found in the file.");
                }
                else
                {
                    Console.WriteLine($"The word '{word}' is not found in the file.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
            }
        }

        static void SearchWordsInFile(string filePath, string word)
        {
            try
            {
                string fileContent = File.ReadAllText(filePath);
                bool found = fileContent.Contains(word);
                int count = 0;

                if (found)
                {
                    string[] words = fileContent.Split(new char[] { ' ', ',', '.', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string _word in words)
                    {
                        if (_word == word)
                        {
                            count++;
                        }
                    }

                    Console.WriteLine($"Count of {word} : {count}");
                }
                else
                {
                    Console.WriteLine($"The word '{word}' is not found in the file.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
            }
        }

        static void SearchWordReverseInFile(string filePath, string word)
        {
            try
            {
                string fileContent = File.ReadAllText(filePath);
                string reversedword = ReverseString(word);
                bool found = fileContent.Contains(reversedword);

                if (found)
                {
                    Console.WriteLine($"The word '{reversedword}' is found in the file.");
                }
                else
                {
                    Console.WriteLine($"The word '{reversedword}' is not found in the file.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
            }
        }

        static string ReverseString(string input)
        {
            char[] charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }

        static void DisplayFileStatistics(string filePath)
        {
            try
            {
                string fileContent = File.ReadAllText(filePath);

                int sentenceCount = CountSentences(fileContent);
                int uppercaseCount = CountUppercaseLetters(fileContent);
                int lowercaseCount = CountLowercaseLetters(fileContent);
                int vowelCount = CountVowels(fileContent);
                int consonantCount = CountConsonants(fileContent);
                int digitCount = CountDigits(fileContent);

                Console.WriteLine($"Number of sentences: {sentenceCount}");
                Console.WriteLine($"Number of uppercase letters: {uppercaseCount}");
                Console.WriteLine($"Number of lowercase letters: {lowercaseCount}");
                Console.WriteLine($"Number of vowels: {vowelCount}");
                Console.WriteLine($"Number of consonants: {consonantCount}");
                Console.WriteLine($"Number of digits: {digitCount}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while reading the file: {ex.Message}");
            }
        }

        static int CountSentences(string text)
        {
            string[] sentences = text.Split(new char[] { '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
            return sentences.Length;
        }

        static int CountUppercaseLetters(string text)
        {
            return text.Count(char.IsUpper);
        }

        static int CountLowercaseLetters(string text)
        {
            return text.Count(char.IsLower);
        }

        static int CountVowels(string text)
        {
            string vowels = "aeiouAEIOU";
            return text.Count(c => vowels.Contains(c));
        }

        static int CountConsonants(string text)
        {
            string vowels = "aeiouAEIOU";
            return text.Count(c => char.IsLetter(c) && !vowels.Contains(c));
        }

        static int CountDigits(string text)
        {
            return text.Count(char.IsDigit);
        }
    }
}

