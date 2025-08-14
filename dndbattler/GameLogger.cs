public sealed class GameLogger
{
        private static readonly GameLogger _instance = new GameLogger();

        private GameLogger() { }

        public static GameLogger Instance => _instance;

        public void Log(string message)
        {
            var oldColor = Console.ForegroundColor;
            // Print the timestamp in read
            Console.ForegroundColor = ConsoleColor.Red;
            System.Console.Write($"[{DateTime.Now:T}] ");
            Console.ForegroundColor = oldColor;
            System.Console.WriteLine($"{message}");
        }

}