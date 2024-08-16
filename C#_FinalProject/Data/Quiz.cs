public class Quiz
{
    public string Category { get; set; }
    public List<Question> Questions { get; set; } = new List<Question>();

    public QuizResult Start(User user, UserService userService)
    {
        int correctAnswersCount = 0;

        foreach (var question in Questions)
        {
            Console.Clear();
            Console.WriteLine(question.Text);
            for (int i = 0; i < question.Options.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {question.Options[i]}");
            }

            Console.WriteLine("Enter the numbers of your answers separated by commas (e.g., 1,2):");
            var userAnswersIndices = Console.ReadLine().Split(',').Select(index => int.Parse(index.Trim()) - 1).ToList();
            var userAnswers = userAnswersIndices.Select(index => question.Options[index]).ToList();

            if (IsCorrectAnswer(userAnswers, question.CorrectAnswers))
            {
                correctAnswersCount++;
            }
        }

        double percentage = (double)correctAnswersCount / Questions.Count * 100;

        var quizResult = new QuizResult
        {
            Category = Category,
            CorrectAnswersCount = correctAnswersCount,
            Percentage = percentage,
            CompletionDate = DateTime.Now
        };

        user.QuizResults.Add(quizResult);
        userService.UpdateUser(user);

        return quizResult;
    }


    private bool IsCorrectAnswer(List<string> userAnswers, List<string> correctAnswers)
    {
        return !correctAnswers.Except(userAnswers).Any() && !userAnswers.Except(correctAnswers).Any();
    }
}
