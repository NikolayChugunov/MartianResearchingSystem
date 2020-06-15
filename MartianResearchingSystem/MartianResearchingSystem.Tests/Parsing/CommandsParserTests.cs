using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using MartianResearchingSystem.Core.Parsers;
using MartianResearchingSystem.Core.Robots;

namespace MartianResearchingSystem.Tests.Parsing
{
    [TestClass]
    public class CommandsParserTests
    {
        [TestMethod]
        public void Should_ParseCommandsString_Correctly()
        {
            // Arrange.
            const string commandLine = "FLRFFLLFRRRLF";

            var expectedResult = new List<Command>
            {
                Command.MoveForward,
                Command.TurnLeft,
                Command.TurnRight,
                Command.MoveForward,
                Command.MoveForward,
                Command.TurnLeft,
                Command.TurnLeft,
                Command.MoveForward,
                Command.TurnRight,
                Command.TurnRight,
                Command.TurnRight,
                Command.TurnLeft,
                Command.MoveForward
            };

            var target = new CommandsParser();

            // Act.
            var actualResult = target.ParseCommandString(commandLine);

            // Assert.
            CollectionAssert.AreEqual(expectedResult, actualResult);
        }
    }
}
