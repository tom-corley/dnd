using System.IO;
using System.Text;
using NUnit.Framework;

namespace dndbattler.Tests
{
    [TestFixture]
    public class InputAndProgramTests
    {
        [Test]
        public void GetStringFromConsole_Reprompts_On_Blank()
        {
            StringReader input = new StringReader("\nGary");
            StringWriter output = new StringWriter();
            var originalOut = Console.Out;
            var originalIn = Console.In;
            Console.SetIn(input); Console.SetOut(output);

            Program.GetStringFromConsole("Please Enter Team Name: ");
            string result = output.ToString();

            Assert.That(result, Does.Contain("Input cannot be left blank"));

            Console.SetIn(originalIn); Console.SetOut(originalOut);
        }

        [Test]
        public void GetCharacterTypeFromConsole_Reprompts_On_Invalid()
        {
            StringReader input = new StringReader("Mage\nCleric");
            StringWriter output = new StringWriter();
            var originalOut = Console.Out;
            var originalIn = Console.In;
            Console.SetIn(input); Console.SetOut(output);

            Program.GetCharacterTypeFromConsole();
            string result = output.ToString();

            Assert.That(result, Does.Contain("Invalid Character Type."));

            Console.SetIn(originalIn); Console.SetOut(originalOut);
        }

        [Test]
        public void Check_GetTeamFromUser_Returns_A_Team()
        {
            Random rng = new Random();
            CharacterFactory factory = new CharacterFactory(rng);

            var sb = new StringBuilder();
            sb.AppendLine("testClerics");
            for (int i = 0; i < GameConstants.TEAM_SIZE; i++)
            {
                sb.AppendLine("Cleric");
                sb.AppendLine($"Cleric {i}");
            }

            StringReader input = new StringReader(sb.ToString());
            StringWriter output = new StringWriter();
            var originalOut = Console.Out;
            var originalIn = Console.In;
            Console.SetIn(input); Console.SetOut(output);

            Team result = Program.GetTeamFromUser(factory);

            Assert.That(result, Is.Not.Null);
            Assert.That(result.Name, Is.EqualTo("testClerics"));
            Assert.That(result.Members.Count, Is.EqualTo(GameConstants.TEAM_SIZE));

            Console.SetIn(originalIn); Console.SetOut(originalOut);
        }

        [Test]
        public void Check_Full_Game_Runs()
        {
            Random rng = new Random();
            CharacterFactory factory = new CharacterFactory(rng);

            var sb = new StringBuilder();
            sb.AppendLine("testClerics");
            for (int i = 0; i < GameConstants.TEAM_SIZE; i++)
            {
                sb.AppendLine("Cleric");
                sb.AppendLine($"Cleric {i}");
            }
            sb.AppendLine("testWizards");
            for (int i = 0; i < GameConstants.TEAM_SIZE; i++)
            {
                sb.AppendLine("Wizard");
                sb.AppendLine($"Wizard {i}");
            }


            StringReader input = new StringReader(sb.ToString());
            StringWriter output = new StringWriter();
            var originalOut = Console.Out;
            var originalIn = Console.In;
            Console.SetIn(input); Console.SetOut(output);

            Program.Main(Array.Empty<string>());
            string result = output.ToString();
            Assert.That(result, Does.Contain("Battle Concluded:"));

            Console.SetIn(originalIn); Console.SetOut(originalOut);
        }
    }
}
