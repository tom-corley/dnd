using System;
using System.IO;
using NUnit.Framework;

namespace dndbattler.Tests
{
    [TestFixture]
    public class GameLoggerTests
    {
        [Test]
        public void Logs_Message_With_Timestamp()
        {
            GameLogger logger = GameLogger.Instance;
            StringWriter new_out = new StringWriter();
            TextWriter old_out = Console.Out;
            Console.SetOut(new_out);

            logger.Log("Test message");

            // Assert
            string output = new_out.ToString();
            Assert.That(output, Does.Contain("Test message"));
            Assert.That(output, Does.Match(@"\[\d{1,2}:\d{2}:\d{2}")); // hours, minutes, seconds
        }    
    }
}