public class BattleEngine
{
    public Team Team1;
    public Team Team2;
    public int TeamSize;
    public static GameLogger logger = GameLogger.Instance;
    private Random _rng;
    public BattleEngine(Team team1, Team team2, Random rng)
    {
        Team1 = team1;
        Team2 = team2; // These are checked to be the same size earlier (both to the set team size)
        _rng = rng;
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

            // Check attacking player is alive, otherwise skip
            attackingPlayer = playingTeam.Members[turn % TeamSize];
            if (!attackingPlayer.Alive)
            {
                turn = (turn + 1) % (2 * TeamSize);
                continue;
            }

            // Find a random target who is alive
            do
            {
                targetedPlayer = opposingTeam.Members[_rng.Next() % TeamSize];
            }
            while (!targetedPlayer.Alive);

            // Announce round, carry out attack and log events
            logger.Log($"===ROUND {roundNumber}===");
            string attack_log;
            int res = attackingPlayer.AttackCharacter(targetedPlayer, out attack_log);
            logger.Log(attack_log);


            // Print status of players
            logger.Log(Team1.ToString()); logger.Log(Team2.ToString()); logger.Log("");

            // Iterate turn and round number
            turn = (turn + 1) % (2 * TeamSize);
            roundNumber++; // not iterated unless attack happens
        }

        // Results log
        logger.Log(
            "Battle Concluded: "
            +(Team1.IsAlive ? $"{Team1.Name} wins" : $"{Team2.Name} wins")
        );
    }
}