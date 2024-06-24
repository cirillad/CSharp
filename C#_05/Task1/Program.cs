namespace C__05
{
    class Worker
    {
        private string initials;
        private float salary;
        private int age;
        private DateTime employmentDate;

        public string Initials
        {
            get { return initials; }
            set 
            {
                if (string.IsNullOrWhiteSpace(value)) 
                {
                    throw new Exception("You must write something.");
                }

                initials = value;
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                if (value < 18 || value > 65)
                {
                    throw new Exception("It must be an integer number between 18 and 65.");
                }

                age = value;
            }
        }

        public float Salary
        {
            get { return salary; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("It can't be less than or equal to 0.");
                }

                salary = value;
            }
        }

        public DateTime EmploymentDate
        {
            get { return employmentDate; }
            set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("DateTime ERROR");

                employmentDate = value;
            }
        }

        public int WorkExperience()
        {
            return DateTime.Now.Year - EmploymentDate.Year;
        }

        public Worker(string initials, int age, float salary, DateTime employmentDate)
        {
            Initials = initials;
            Age = age;
            Salary = salary;
            EmploymentDate = employmentDate;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Worker> workers = new List<Worker>();

            for (int i = 0; i < 5; i++)
            {
                while (true)
                {
                    try
                    {
                        Console.Write($"Enter initials of worker {i + 1}: ");
                        string initials = Console.ReadLine();

                        Console.Write($"Enter age of worker {i + 1}: ");
                        int age = int.Parse(Console.ReadLine());

                        Console.Write($"Enter salary of worker {i + 1}: ");
                        float salary = float.Parse(Console.ReadLine());

                        Console.Write($"Enter employment date of worker {i + 1} (yyyy-MM-dd): ");
                        DateTime employmentDate = DateTime.Parse(Console.ReadLine());

                        workers.Add(new Worker(initials, age, salary, employmentDate));
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }
            }

            workers = workers.OrderBy(w => w.Initials).ToList();

            Console.Write("Enter minimum work experience in years: ");
            int minExperience = int.Parse(Console.ReadLine());

            Console.WriteLine("Workers with work experience greater than the specified value:");
            foreach (var worker in workers)
            {
                if (worker.WorkExperience() > minExperience)
                {
                    Console.WriteLine($"{worker.Initials} has {worker.WorkExperience()} years of work experience.");
                }
            }

        }
    }
}
