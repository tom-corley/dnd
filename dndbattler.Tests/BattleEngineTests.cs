namespace dndbattler.Tests
{
    [TestFixture]
    public class BattleEngineTests
    {
        [Test]
        public void Game_Runs_To_Completion()
        {
            Random rng = new Random(0);
            CharacterFactory factory = new CharacterFactory(rng);
            TeamBuilder builder = new TeamBuilder(factory);

            for (int i = 0; i < GameConstants.TEAM_SIZE; i++)
            {
                builder.AddMember(CharacterType.Fighter, $"Character {i}");
            }
            builder.Name("Testers1");
            Team testers1 = builder.Build();

            TeamBuilder builder2 = new TeamBuilder(factory);
            for (int i = 0; i < GameConstants.TEAM_SIZE; i++)
            {
                builder2.AddMember(CharacterType.Wizard, $"Character {i}");
            }
            builder2.Name("Testers2");
            Team testers2 = builder2.Build();

            BattleEngine game = new BattleEngine(testers1, testers2, rng);

            // Capture Logs
            StringWriter simulatedConsole = new StringWriter();
            var originalOut = Console.Out;
            Console.SetOut(simulatedConsole);
            game.Run();

            string consoleOutput = simulatedConsole.ToString();
            Assert.That(consoleOutput, Does.Contain("Battle Concluded:"));
            Assert.That(testers1.IsAlive && testers2.IsAlive, Is.False);
        }
    }
}