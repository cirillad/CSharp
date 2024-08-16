using System.Text.Json;

public class QuizService
{
    private readonly UserService _userService;
    private List<Quiz> _quizzes = new List<Quiz>();
    private const string QuestionsDirectory = "Questions/";

    public string GetQuestionsDirectory()
    {
        return QuestionsDirectory;
    }

    public QuizService(UserService userService)
    {
        _userService = userService;
        EnsureQuestionsDirectoryExists();
        LoadQuizzes();
    }

    public Quiz GetQuiz(string category)
    {
        return _quizzes.Find(q => q.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
    }

    public Quiz GetRandomMixedQuiz()
    {
        var allQuestions = _quizzes.SelectMany(q => q.Questions).ToList();
        var random = new Random();
        var mixedQuestions = allQuestions.OrderBy(x => random.Next()).Take(10).ToList();

        var specialQuestion = _quizzes.SelectMany(q => q.Questions)
            .FirstOrDefault(q => q.Options.Count == 2 && q.CorrectAnswers.Count == 2);

        if (specialQuestion != null)
        {
            mixedQuestions.Add(specialQuestion);
        }

        return new Quiz
        {
            Category = "Mixed",
            Questions = mixedQuestions
        };
    }

    private void EnsureQuestionsDirectoryExists()
    {
        if (!Directory.Exists(QuestionsDirectory))
        {
            Directory.CreateDirectory(QuestionsDirectory);
        }
    }

    public void LoadQuizzes()
    {
        _quizzes.Clear();

        var files = Directory.GetFiles(QuestionsDirectory, "*Questions.json");
        foreach (var file in files)
        {
            var category = Path.GetFileNameWithoutExtension(file).Replace("Questions", "").Trim();
            var quiz = LoadQuizFromFile(file, category);
            if (quiz != null)
            {
                _quizzes.Add(quiz);
            }
        }
    }

    private Quiz LoadQuizFromFile(string filePath, string category)
    {
        if (!File.Exists(filePath))
        {
            return null;
        }

        var jsonData = File.ReadAllText(filePath);
        var questionData = JsonSerializer.Deserialize<QuestionData>(jsonData);
        return new Quiz
        {
            Category = category,
            Questions = questionData?.Questions ?? new List<Question>()
        };
    }

    public void SaveQuiz(Quiz quiz)
    {
        string filePath = Path.Combine(QuestionsDirectory, $"{quiz.Category}Questions.json");

        var questionData = new QuestionData { Questions = quiz.Questions };
        var jsonData = JsonSerializer.Serialize(questionData, new JsonSerializerOptions { WriteIndented = true });

        File.WriteAllText(filePath, jsonData);
    }

    public List<string> GetCategories()
    {
        var categories = _quizzes.Select(q => q.Category).Distinct().ToList();
        categories.Add("Mixed");
        return categories;
    }

    public void StartQuiz(Quiz quiz, User user)
    {
        // Логіка проведення квізу
    }
}
