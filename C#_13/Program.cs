using System.Text.RegularExpressions;

namespace C__13
{
    class PhoneBook
    {
        Dictionary<string, string> phoneNumbers;

        public PhoneBook()
        {
            phoneNumbers = new Dictionary<string, string>();
        }

        public void AddUser(string username, string phoneNumber)
        {
            phoneNumbers.Add(username, phoneNumber);
        }

        public void DeleteUser(string username)
        {
            phoneNumbers.Remove(username);
        }

        public void ChangeUser(string username, string phoneNumber)
        {
            if (phoneNumbers.ContainsKey(username)) 
            {
                phoneNumbers[username] = phoneNumber;
            }
            else 
            {
                Console.WriteLine("User not found");
            }
        }

        public void SearchUser(string username)
        {
            if (phoneNumbers.ContainsKey(username))
            {
                Console.WriteLine($"{username}: {phoneNumbers[username]}");
            }
            else
            {
                Console.WriteLine($"User not found");
            }
        }

        public void Show()
        {
            foreach (var phoneNumber in phoneNumbers)
            {
                Console.WriteLine($"{phoneNumber.Key}: {phoneNumber.Value}");
            }
        }
    }

    public class WordCounter
    {
        public Dictionary<string, int> CountWords(string text)
        {
            var words = Regex.Matches(text.ToLower(), @"\b[\w']+\b");

            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            foreach (Match match in words)
            {
                string word = match.Value;

                if (wordCounts.ContainsKey(word))
                {
                    wordCounts[word]++;
                }
                else
                {
                    wordCounts[word] = 1;
                }
            }

            return wordCounts;
        }

        public void PrintWordCounts(Dictionary<string, int> wordCounts)
        {
            Console.WriteLine("Слово\t\tКількість");

            foreach (var entry in wordCounts.OrderByDescending(e => e.Value))
            {
                Console.WriteLine($"{entry.Key}\t\t{entry.Value}");
            }
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            //Task1();
            Task2();
        }

        static void Task1()
        {
            PhoneBook phoneBook = new PhoneBook();

            phoneBook.AddUser("John Doe", "123-456-7890");
            phoneBook.AddUser("Jane Smith", "987-654-3210");

            phoneBook.SearchUser("John Doe");

            phoneBook.ChangeUser("John Doe", "111-222-3333");
            phoneBook.SearchUser("John Doe");

            phoneBook.Show();

            phoneBook.DeleteUser("Jane Smith");
            phoneBook.Show();
        }

        static void Task2()
        {
            string text = "Ось будинок, який збудував Джек. А це пшениця, яка\r\nу темній коморі зберігається у будинку, який збудував\r\nДжек. А це веселий птах-синиця, який часто краде\r\nпшеницю, яка в темній коморі зберігається у будинку,\r\nякий збудував Джек.";

            WordCounter wordCounter = new WordCounter();

            var wordCounts = wordCounter.CountWords(text);

            wordCounter.PrintWordCounts(wordCounts);
        }
    }
}
