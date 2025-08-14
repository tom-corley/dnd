public class BattleEngine
{
    public Team Team1;
    public Team Team2;
    public int TeamSize;
    public static GameLogger logger = GameLogger.Instance;
    private Random rng;
    public BattleEngine(Team team1, Team team2, int seed = 0)
    {
        Team1 = team1;
        Team2 = team2;
        rng = new Random(seed);

        if (team1.Members.Count != team2.Members.Count)
        {
            throw new Exception("Teams must be of equal size");
        }
        TeamSize = team1.Members.Count;
    }

    public void Run()
    {
        // Setup
        int turn = 0; // Loops using modular arithmetic
        int num_players = 2 * Team1.Members.Count;
        Team playingTeam;
        Team opposingTeam;
        Character attackingPlayer;
        Character targetedPlayer;
        int roundNumber = 1;

        // Print status of players
        logger.Log("Starting Battle\nHere are the teams:");
        logger.Log($"{Team1}\n{Team2}");
        
        // Main game loop
        while (Team1.IsAlive && Team2.IsAlive)
        {
            // For example for 6 players, 0,1,2 vs 3,4,5
            playingTeam = turn < TeamSize ? Team1 : Team2;
            opposingTeam = turn >= TeamSize ? Team1 : Team2;

            // Player attacks
            attackingPlayer = playingTeam.Members[turn % TeamSize];
            if (!attackingPlayer.Alive)
            {
                turn = (turn + 1) % (2 * TeamSize);
                continue;
            }
            do
            {
                targetedPlayer = opposingTeam.Members[rng.Next() % TeamSize];
            }
            while (!targetedPlayer.Alive);
            logger.Log($"===ROUND {roundNumber}===");
            string attack_log;
            int res = attackingPlayer.AttackCharacter(targetedPlayer, out attack_log);
            logger.Log(attack_log);


            // Print status of players
            logger.Log(Team1.ToString()); logger.Log(Team2.ToString()); logger.Log("");

            // Iterate turn and round number
            turn = (turn + 1) % (2 * TeamSize);
            roundNumber++;
        }

        // Results log
        logger.Log(
            "Battle Concluded: "
            +(Team1.IsAlive ? $"{Team1.Name} wins" : $"{Team2.Name} wins")
        );
    }
}