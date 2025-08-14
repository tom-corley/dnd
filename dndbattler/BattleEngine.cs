public class BattleEngine
{
    public Team Team1;
    public Team Team2;
    public int TeamSize;

    public GameLogger logger = GameLogger.Instance;
    public BattleEngine(Team team1, Team team2)
    {
        Team1 = team1;
        Team2 = team2;

        if (team1.Members.Count != team2.Members.Count)
        {
            throw new Exception("Teams must be equal");
        }
        TeamSize = team1.Members.Count;

    }

    public void Run()
    {
        int turn = 0; // Loops using modular arithmetic
        int num_players = 2 * Team1.Members.Count;
        Team playingTeam;
        Team opposingTeam;

        while (Team1.IsAlive() && Team2.IsAlive())
        {
            // For example for 6 players, 0,1,2 vs 3,4,5
            if (turn < num_players / 2)
            {
                playingTeam = Team1;
                opposingTeam = Team2;
            }
            else
            {
                playingTeam = Team2;
                opposingTeam = Team1;
            }

            // Assumption here is character attacks the opposite character
            playingTeam.Members[turn % 3].AttackCharacter(playingTeam.Members[turn % 3]);
        }
    }
}