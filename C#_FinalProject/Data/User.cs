public class User
{
    public string Login { get; set; }
    public string Password { get; set; }
    public DateTime DateOfBirth { get; set; }
    public List<QuizResult> QuizResults { get; set; } = new List<QuizResult>();

    public double GetAveragePercentage()
    {
        if (QuizResults.Count == 0)
            return 0;

        return Math.Round(QuizResults.Average(result => result.Percentage), 1);
    }
}
