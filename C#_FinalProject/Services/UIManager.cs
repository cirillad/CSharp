public class UIManager
{
    private readonly UserService _userService;
    private readonly QuizService _quizService;
    private User _currentUser;

    private const string AdminLogin = "admin";
    private const string AdminPassword = "admin123";

    public UIManager(UserService userService, QuizService quizService)
    {
        _userService = userService;
        _quizService = quizService;
    }

    public void Run()
    {
        int selectedIndex = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Use the arrow keys to navigate and Enter to select.");

            DisplayMenu(selectedIndex);

            var key = Console.ReadKey(intercept: true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = (selectedIndex - 1 + 4) % 4;
                    break;
                case ConsoleKey.DownArrow:
                    selectedIndex = (selectedIndex + 1) % 4;
                    break;
                case ConsoleKey.Enter:
                    switch (selectedIndex)
                    {
                        case 0:
                            _currentUser = Login(false);
                            if (_currentUser != null)
                            {
                                ShowMainMenu();
                            }
                            break;
                        case 1:
                            Console.Clear();
                            Console.WriteLine("Enter login:");
                            string adminLogin = Console.ReadLine();

                            Console.WriteLine("Enter password:");
                            string adminPassword = Console.ReadLine();

                            if (adminLogin == AdminLogin && adminPassword == AdminPassword)
                            {
                                Console.Clear();
                                Console.WriteLine("Welcome, Admin!");
                                ShowAdminMenu();
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Invalid admin credentials. Press any key to try again...");
                                Console.ReadKey();
                            }
                            break;
                        case 2:
                            Register(); 
                            break;
                        case 3:
                            return;
                    }
                    break;
            }
        }
    }




    private void DisplayMenu(int selectedIndex)
    {
        string[] options = { "Login", "Login as Admin", "Register", "Exit" };

        for (int i = 0; i < options.Length; i++)
        {
            if (i == selectedIndex)
            {
                Console.WriteLine($"-> {options[i]}");
            }
            else
            {
                Console.WriteLine($"   {options[i]}");
            }
        }
    }

    private User Login(bool isAdmin)
    {
        Console.Clear();
        Console.WriteLine("Enter login:");
        string login = Console.ReadLine();
        Console.WriteLine("Enter password:");
        string password = Console.ReadLine();

        if (isAdmin)
        {
            if (login == AdminLogin && password == AdminPassword)
            {
                Console.Clear();
                Console.WriteLine("Welcome, Admin!");
                return null; 
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid admin credentials. Press any key to try again...");
                Console.ReadKey();
                return null;
            }
        }
        else
        {
            var user = _userService.Login(login, password);

            if (user != null)
            {
                Console.Clear();
                Console.WriteLine($"Welcome, {user.Login}!");
                return user;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid login or password. Press any key to try again...");
                Console.ReadKey();
                return null;
            }
        }
    }


    private void Register(bool isAdmin = false)
    {
        Console.Clear();
        Console.WriteLine("Enter login:");
        string login = Console.ReadLine();
        Console.WriteLine("Enter password:");
        string password = Console.ReadLine();

        if (isAdmin)
        {
            // Admin registration logic
            if (login == AdminLogin && password == AdminPassword)
            {
                Console.Clear();
                Console.WriteLine("Admin already exists. Press any key to return to the menu...");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Invalid admin credentials. Press any key to try again...");
                Console.ReadKey();
                return;
            }
        }

        Console.WriteLine("Enter date of birth (yyyy-MM-dd):");
        DateTime dateOfBirth;
        while (!DateTime.TryParse(Console.ReadLine(), out dateOfBirth))
        {
            Console.WriteLine("Invalid date format. Please enter date of birth (yyyy-MM-dd):");
        }

        var user = new User { Login = login, Password = password, DateOfBirth = dateOfBirth };
        if (_userService.Register(user))
        {
            Console.Clear();
            Console.WriteLine("Registration successful. Press any key to return to the menu...");
        }
        else
        {
            Console.Clear();
            Console.WriteLine("Registration failed. Login already exists. Press any key to try again...");
        }

        Console.ReadKey();
    }



    private void ShowMainMenu()
    {
        int selectedIndex = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Use the arrow keys to navigate and Enter to select.");

            DisplayMainMenu(selectedIndex);

            var key = Console.ReadKey(intercept: true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = (selectedIndex - 1 + 4) % 4;
                    break;
                case ConsoleKey.DownArrow:
                    selectedIndex = (selectedIndex + 1) % 4;
                    break;
                case ConsoleKey.Enter:
                    switch (selectedIndex)
                    {
                        case 0:
                            StartQuiz();
                            break;
                        case 1:
                            ViewQuizResults();
                            break;
                        case 2:
                            ShowTop20Players();
                            break;
                        case 3:
                            return;
                    }
                    break;
            }
        }
    }

    private void ShowAdminMenu()
    {
        int selectedIndex = 0;

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Use the arrow keys to navigate and Enter to select.");

            DisplayAdminMenu(selectedIndex);

            var key = Console.ReadKey(intercept: true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = (selectedIndex - 1 + 3) % 3;
                    break;
                case ConsoleKey.DownArrow:
                    selectedIndex = (selectedIndex + 1) % 3;
                    break;
                case ConsoleKey.Enter:
                    switch (selectedIndex)
                    {
                        case 0:
                            AddNewQuiz();
                            break;
                        case 1:
                            DeleteQuiz();
                            break;
                        case 2:
                            return;
                    }
                    break;
            }
        }
    }

    private void DeleteQuiz()
    {
        int selectedIndex = 0;
        List<string> categories = _quizService.GetCategories();
        categories.Add("Back");

        while (true)
        {
            Console.Clear();
            DisplayCategoryMenu(categories, selectedIndex);

            var key = Console.ReadKey(intercept: true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = (selectedIndex - 1 + categories.Count) % categories.Count;
                    break;
                case ConsoleKey.DownArrow:
                    selectedIndex = (selectedIndex + 1) % categories.Count;
                    break;
                case ConsoleKey.Enter:
                    if (selectedIndex == categories.Count - 1)
                    {
                        return;
                    }

                    string categoryToDelete = categories[selectedIndex];
                    string filePath = Path.Combine(_quizService.GetQuestionsDirectory(), $"{categoryToDelete}Questions.json");

                    if (File.Exists(filePath))
                    {
                        File.Delete(filePath);
                        Console.Clear();
                        Console.WriteLine("Quiz deleted successfully.");
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Quiz not found.");
                    }

                    _quizService.LoadQuizzes();
                    categories = _quizService.GetCategories();
                    categories.Add("Back");

                    Console.WriteLine("Press any key to return to the menu...");
                    Console.ReadKey();
                    break;
            }
        }
    }


    private void DisplayMainMenu(int selectedIndex)
    {
        string[] options = { "Start new quiz", "View quiz results", "View Top 20 Players", "Exit" };

        for (int i = 0; i < options.Length; i++)
        {
            if (i == selectedIndex)
            {
                DisplayColoredText($"-> {options[i]}", ConsoleColor.Cyan, ConsoleColor.Black);
            }
            else
            {
                Console.WriteLine($"   {options[i]}");
            }
        }
    }

    private void DisplayAdminMenu(int selectedIndex)
    {
        string[] options = { "Add new quiz", "Delete quiz", "Exit" };

        for (int i = 0; i < options.Length; i++)
        {
            if (i == selectedIndex)
            {
                DisplayColoredText($"-> {options[i]}", ConsoleColor.Cyan, ConsoleColor.Black);
            }
            else
            {
                Console.WriteLine($"   {options[i]}");
            }
        }
    }



    private void ViewQuizResults()
    {
        Console.Clear();

        if (_currentUser.QuizResults.Count == 0)
        {
            Console.WriteLine("No quiz results found.");
        }
        else
        {
            Console.WriteLine("Your quiz results:");
            foreach (var result in _currentUser.QuizResults)
            {
                Console.WriteLine($"Category: {result.Category}");
                Console.WriteLine($"Correct Answers: {result.CorrectAnswersCount}");
                Console.WriteLine($"Score: {result.Percentage}%");
                Console.WriteLine($"Completion Date: {result.CompletionDate}");
                Console.WriteLine();
            }
        }

        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }


    private void StartQuiz()
    {
        int selectedIndex = 0;

        while (true)
        {
            Console.Clear();
            DisplayColoredText("Select quiz option:", ConsoleColor.Green, ConsoleColor.Black);

            var categories = _quizService.GetCategories();
            categories.Add("Back");

            DisplayCategoryMenu(categories, selectedIndex);

            var key = Console.ReadKey(intercept: true).Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    selectedIndex = (selectedIndex - 1 + categories.Count) % categories.Count;
                    break;
                case ConsoleKey.DownArrow:
                    selectedIndex = (selectedIndex + 1) % categories.Count;
                    break;
                case ConsoleKey.Enter:
                    if (selectedIndex == categories.Count - 1)
                    {
                        return;
                    }

                    string category = categories[selectedIndex];
                    Quiz quiz = category == "Mixed" ? _quizService.GetRandomMixedQuiz() : _quizService.GetQuiz(category);

                    if (quiz != null)
                    {
                        var result = quiz.Start(_currentUser, _userService);
                        Console.Clear();
                        DisplayColoredText($"Number of correct answers: {result.CorrectAnswersCount}", ConsoleColor.Yellow, ConsoleColor.Black);
                        DisplayColoredText($"Your score: {result.Percentage}%", ConsoleColor.Yellow, ConsoleColor.Black);

                        Console.WriteLine("Would you like to review the questions and answers? (y/n)");
                        if (Console.ReadLine().ToLower() == "y")
                        {
                            ReviewQuizQuestions(quiz);
                        }
                    }
                    else
                    {
                        DisplayColoredText("Quiz not found for the selected category.", ConsoleColor.Red, ConsoleColor.Black);
                    }
                    break;
            }
        }
    }

    private void DisplayCategoryMenu(List<string> categories, int selectedIndex)
    {
        Console.Clear();
        Console.WriteLine("Select the quiz category to delete:");

        for (int i = 0; i < categories.Count; i++)
        {
            if (i == selectedIndex)
            {
                Console.WriteLine($"-> {categories[i]}");
            }
            else
            {
                Console.WriteLine($"   {categories[i]}");
            }
        }
    }


    private void ReviewQuizQuestions(Quiz quiz)
    {
        Console.Clear();
        DisplayColoredText("Review Quiz Questions", ConsoleColor.Magenta, ConsoleColor.Black);

        foreach (var question in quiz.Questions)
        {
            Console.WriteLine($"Question: {question.Text}");
            for (int i = 0; i < question.Options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {question.Options[i]}");
            }

            Console.WriteLine("Correct Answers:");
            foreach (var answer in question.CorrectAnswers)
            {
                Console.WriteLine($"- {answer}");
            }

            Console.WriteLine();
        }

        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }

    private void ShowTop20Players()
    {
        var topPlayers = _userService.GetTop20Players();
        Console.Clear();

        if (topPlayers.Count == 0)
        {
            Console.WriteLine("No players found.");
        }
        else
        {
            Console.WriteLine("Top 20 Players:");
            int rank = 1;
            foreach (var player in topPlayers)
            {
                Console.WriteLine($"{rank}. {player.Login} - Average Score: {player.GetAveragePercentage()}%");
                rank++;
            }
        }

        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }

    private void AddNewQuiz()
    {
        Console.Clear();
        Console.WriteLine("Enter the category for the new quiz (e.g., History, Geography):");
        string category = Console.ReadLine();

        var questions = new List<Question>();
        while (true)
        {
            Console.WriteLine("Enter the question text (or type 'done' to finish):");
            string questionText = Console.ReadLine();
            if (questionText.ToLower() == "done")
            {
                break;
            }

            var question = new Question { Text = questionText };

            Console.WriteLine("Enter the options for the question, separated by commas:");
            question.Options = Console.ReadLine().Split(',').Select(option => option.Trim()).ToList();

            Console.WriteLine("Enter the correct answers for the question, separated by commas:");
            question.CorrectAnswers = Console.ReadLine().Split(',').Select(answer => answer.Trim()).ToList();

            questions.Add(question);
        }

        var newQuiz = new Quiz { Category = category, Questions = questions };
        _quizService.SaveQuiz(newQuiz);

        _quizService.LoadQuizzes();

        Console.Clear();
        Console.WriteLine("New quiz added successfully.");
        Console.WriteLine("Press any key to return to the main menu...");
        Console.ReadKey();
    }

    private void DisplayColoredText(string text, ConsoleColor textColor, ConsoleColor backgroundColor)
    {
        var originalForeground = Console.ForegroundColor;
        var originalBackground = Console.BackgroundColor;

        Console.ForegroundColor = textColor;
        Console.BackgroundColor = backgroundColor;
        Console.WriteLine(text);

        Console.ForegroundColor = originalForeground;
        Console.BackgroundColor = originalBackground;
    }
}
