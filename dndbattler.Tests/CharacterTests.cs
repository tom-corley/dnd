using System.Net.Sockets;
using NUnit.Framework;

namespace dndbattler.Tests
{
    [TestFixture]
    public class CharacterTests
    {
        [Test]
        public void Fighter_Has_Health_Bonus()
        {
            Random rng = new Random(0);
            {
                CharacterFactory factory = new CharacterFactory(rng);
                Character testFighter = factory.Create(CharacterType.Fighter, "TestFighter");
                Assert.That(testFighter, Is.Not.Null);
                Assert.That(testFighter.MaxHealth, Is.GreaterThanOrEqualTo(GameConstants.MIN_STAT + GameConstants.FIGHTER_HEALTH_BONUS));
            }
        }

        [Test]
        public void Cleric_Has_Health_Bonus()
        {
            // Arrange
            Random rng = new Random(0);
            CharacterFactory factory = new CharacterFactory(rng);
            Character testCleric = factory.Create(CharacterType.Cleric, "TestCleric");
            testCleric.TakeDamage(GameConstants.CLERIC_SELF_HEAL);
            Character testVictim = factory.Create(CharacterType.Fighter, "TestVictim");
            string log;

            // Act
            testCleric.AttackCharacter(testVictim, out log);

            // Assert
            Assert.That(testCleric.Health, Is.EqualTo(testCleric.MaxHealth));
        }

        [Test]
        public void Wizard_Has_Attack_Recoil()
        {
            // Arrange
            Random rng = new Random(0);
            CharacterFactory factory = new CharacterFactory(rng);
            Character testWizard = factory.Create(CharacterType.Wizard, "TestWizard");
            Character testVictim = factory.Create(CharacterType.Fighter, "TestVictim");
            string log;

            // Act
            System.Console.WriteLine(testWizard.Health);
            testWizard.AttackCharacter(testVictim, out log);
            System.Console.WriteLine(testWizard.Health);

            // Assert
            Assert.That(testWizard.Health, Is.EqualTo(testWizard.MaxHealth - GameConstants.WIZARD_SELF_DAMAGE));
        }

        [Test]
        public void Wizard_Can_Suicide()
        {
            // Arrange
            Random rng = new Random(0);
            CharacterFactory factory = new CharacterFactory(rng);
            Character testWizard = factory.Create(CharacterType.Wizard, "TestWizard");
            Character testVictim = factory.Create(CharacterType.Fighter, "TestVictim");
            string log;

            // Act
            for (int i = 0; i < (testWizard.MaxHealth / GameConstants.WIZARD_SELF_DAMAGE) + 1; i++)
            {
                testWizard.AttackCharacter(testVictim, out log);
            }

            // Assert
            Assert.That(testWizard.Alive, Is.False);
        }

        [Test]
        public void Cleric_Cannot_Heal_Above_Max_Health()
        {
            // Arrange
            Random rng = new Random(0);
            CharacterFactory factory = new CharacterFactory(rng);
            Character testCleric = factory.Create(CharacterType.Cleric, "TestCleric");
            Character testVictim = factory.Create(CharacterType.Fighter, "TestVictim");
            string log;

            // Act
            testCleric.AttackCharacter(testVictim, out log);

            // Assert
            Assert.That(testCleric.Health, Is.EqualTo(testCleric.MaxHealth));
        }

        [Test]
        public void Characters_Die_Correctly()
        {
            // Arrange
            Random rng = new Random(0);
            CharacterFactory factory = new CharacterFactory(rng);
            Character testMurderer = new Fighter("One punch man", GameConstants.MAX_STAT + 5, GameConstants.MAX_STAT + 5);
            Character testVictim1 = factory.Create(CharacterType.Fighter, "TestVictim1");
            Character testVictim2 = factory.Create(CharacterType.Wizard, "TestVictim2");
            Character testVictim3 = factory.Create(CharacterType.Cleric, "TestVictim3");
            string log;

            // Act
            testMurderer.AttackCharacter(testVictim1, out log);
            testMurderer.AttackCharacter(testVictim2, out log);
            testMurderer.AttackCharacter(testVictim3, out log);

            // Assert
            Assert.That(testVictim1.Alive, Is.False);
            Assert.That(testVictim2.Alive, Is.False);
            Assert.That(testVictim3.Alive, Is.False);
        }

        /*[Test]
        public void CharacterFactory_Throws_When_Type_Invalid()
        {
            Random rng = new Random(0);
            CharacterFactory factory = new CharacterFactory(rng);
            Assert.That(() => factory.Create(CharacterType.d, "FakeType"));
        } */
    }
}