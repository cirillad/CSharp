using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
public class Program
{
    static void Main(string[] args)
    {
        var userService = new UserService();
        var quizService = new QuizService(userService);
        var uiManager = new UIManager(userService, quizService);
        uiManager.Run();
    }
}