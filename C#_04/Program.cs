namespace C__04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Freezer[] freezers =
            [
                new Freezer("LG", 300, 60, 150, 180),
                new Freezer("Samsung", 400, 70, 160, 200),
                new Freezer("Whirlpool", 500, 80, 170, 220),
                new Freezer("Beko", 350, 65, 155, 190),
                new Freezer("Haier", 450, 75, 165, 210),
            ];

            foreach (var freezer in freezers)
            {
                Console.WriteLine(freezer.ToString());
                Console.WriteLine();
            }
        }
    }
}
