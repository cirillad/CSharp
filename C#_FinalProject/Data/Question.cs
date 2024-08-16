public class Question
{
    public string Text { get; set; }
    public List<string> Options { get; set; } = new List<string>();
    public List<string> CorrectAnswers { get; set; } = new List<string>();
}
