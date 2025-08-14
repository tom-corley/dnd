using System;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using NUnit.Framework;

namespace dndbattler.Tests
{
    [TestFixture]
    public class TeamAndTeamBuilderTests
    {
        [Test]
        public void Team_Constructor_Throws_If_Size_Wrong()
        {
            Random rng = new Random(0);
            CharacterFactory factory = new CharacterFactory(rng);
            List<Character> members = new List<Character>();
            for (int i = 0; i < GameConstants.TEAM_SIZE - 1; i++)
            {
                members.Add(factory.Create(CharacterType.Fighter, $"Character {i}"));
            }
            Assert.Throws<Exception>(() =>
            {
                Team _ = new Team("ShouldThrow", members);
            });
        }

        [Test]
        public void Team_Builder_Throws_If_Size_Wrong()
        {
            Random rng = new Random(0);
            CharacterFactory factory = new CharacterFactory(rng);
            TeamBuilder builder = new TeamBuilder(factory);

            for (int i = 0; i < GameConstants.TEAM_SIZE - 1; i++)
            {
                builder.AddMember(CharacterType.Fighter, $"Character {i}");
            }
            Assert.Throws<Exception>(() =>
            {
                builder.Build();
            });
        }

        [Test]
        public void Team_Builder_Refuses_Add_If_Full()
        {
            Random rng = new Random(0);
            CharacterFactory factory = new CharacterFactory(rng);
            TeamBuilder builder = new TeamBuilder(factory);

            for (int i = 0; i < GameConstants.TEAM_SIZE; i++)
            {
                builder.AddMember(CharacterType.Fighter, $"Character {i}");
            }

            Assert.Throws<Exception>(() =>
            {
                builder.AddMember(CharacterType.Fighter, "Should throw");
            });
        }

        [Test]
        public void Team_Builder_Sets_Name_Correctly()
        {
            Random rng = new Random(0);
            CharacterFactory factory = new CharacterFactory(rng);
            TeamBuilder builder = new TeamBuilder(factory);

            for (int i = 0; i < GameConstants.TEAM_SIZE; i++)
            {
                builder.AddMember(CharacterType.Fighter, $"Character {i}");
            }

            builder.Name("Testers");
            Team testers = builder.Build();
            Assert.That(testers.Name, Is.EqualTo("Testers"));
        }

        [Test]
        public void Team_Checks_Alive_Correctly()
        {
            Random rng = new Random(0);
            CharacterFactory factory = new CharacterFactory(rng);
            TeamBuilder builder = new TeamBuilder(factory);

            for (int i = 0; i < GameConstants.TEAM_SIZE; i++)
            {
                builder.AddMember(CharacterType.Fighter, $"Character {i}");
            }
            builder.Name("Testers");
            Team testers = builder.Build();

            Character testMurderer = new Fighter("One punch man", GameConstants.MAX_STAT + 5, GameConstants.MAX_STAT + 5);
            string log;
            for (int i = 0; i < GameConstants.TEAM_SIZE - 1; i++)
            {
                testMurderer.AttackCharacter(testers.Members[i], out log);
            }
            Assert.That(testers.IsAlive, Is.True);
        }

        [Test]
        public void Team_Checks_Dead_Correctly()
        {
            Random rng = new Random(0);
            CharacterFactory factory = new CharacterFactory(rng);
            TeamBuilder builder = new TeamBuilder(factory);

            for (int i = 0; i < GameConstants.TEAM_SIZE; i++)
            {
                builder.AddMember(CharacterType.Fighter, $"Character {i}");
            }
            builder.Name("Testers");
            Team testers = builder.Build();

            Character testMurderer = new Fighter("One punch man", GameConstants.MAX_STAT + 5, GameConstants.MAX_STAT + 5);
            string log;
            for (int i = 0; i < GameConstants.TEAM_SIZE; i++)
            {
                testMurderer.AttackCharacter(testers.Members[i], out log);
            }
            Assert.That(testers.IsAlive, Is.False);

        }

        [Test]
        public void Team_Prints_Correctly()
        {
            Random rng = new Random(0);
            CharacterFactory factory = new CharacterFactory(rng);
            TeamBuilder builder = new TeamBuilder(factory);

            for (int i = 0; i < GameConstants.TEAM_SIZE; i++)
            {
                builder.AddMember(CharacterType.Fighter, $"Character {i}");
            }
            builder.Name("Testers");
            Team testers = builder.Build();

            string printed_team = testers.ToString();
            Assert.That(printed_team, Does.Contain("Testers"));                  // team name appears
            Assert.That(printed_team, Does.Contain("Character 0"));                    // a member appears
            Assert.That(printed_team, Does.Match(@"\d/\d+"));                   // contains "current/max" pattern somewhere
        }
    }
}