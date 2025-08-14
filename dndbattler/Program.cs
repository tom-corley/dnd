public class Program
{
    public static void Main(string[] args)
    {
        // Initialise random number generation and factory 
        Random rng = new Random();
        CharacterFactory factory = new CharacterFactory(rng);

        // Create Teams
        System.Console.WriteLine("\n===CREATING TEAM 1===");
        Team team1 = GetTeamFromUser(factory);
        System.Console.WriteLine("\n===CREATING TEAM 2===");
        Team team2 = GetTeamFromUser(factory);
        System.Console.WriteLine("\n");

        // Launch and Run Game
        BattleEngine game = new BattleEngine(team1, team2, rng);
        game.Run();
    }

    public static Team GetTeamFromUser(CharacterFactory factory)
    {
        // Create Builder
        TeamBuilder builder = new TeamBuilder(factory);

        // Name Team
        string teamName = GetStringFromConsole("Please Enter Team Name: ");
        builder.Name(teamName);

        // Create each team member
        for (int i = 0; i < GameConstants.TEAM_SIZE; i++)
        {
            System.Console.WriteLine($"\nCreating Character {i + 1}...");
            CharacterType charType = GetCharacterTypeFromConsole();
            string charName = GetStringFromConsole("Enter Character Name: ");
            builder.AddMember(charType, charName);
        }

        // Build Team
        return builder.Build();
    }

    public static string GetStringFromConsole(string msg)
    {
        string input;
        while (true)
        {
            System.Console.Write(msg);
            input = Console.ReadLine()?.Trim() ?? "";
            if (!string.IsNullOrWhiteSpace(input)) break;
            Console.WriteLine("Input cannot be left blank. Try again.");
        }
        return input;
    }

    public static CharacterType GetCharacterTypeFromConsole()
    {
        CharacterType charType;
        while (true)
        {
            Console.Write("Enter Character type (Fighter/Wizard/Cleric): ");
            string typeInput = Console.ReadLine()?.Trim() ?? "";
            if (Enum.TryParse(typeInput, true, out charType) &&
                Enum.IsDefined(typeof(CharacterType), charType))
            {
                break;
            }
            Console.WriteLine("Invalid Character Type. Try again.");
        }
        return charType;
    }
}
