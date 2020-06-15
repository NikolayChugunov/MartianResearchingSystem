using System;
using MartianResearchingSystem.Core.Parsers;
using MartianResearchingSystem.Core.Robots;
using MartianResearchingSystem.Core.Spacing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MartianResearchingSystem.Tests.Parsing
{
    [TestClass]
    public class RobotDataParserTests
    {
        [TestMethod]
        public void Should_ParseData_Correctly()
        {
            // Arrange.
            const string robotDataString = "1 3 W";

            var position = new Position(1, 3);
            var orientation = Orientation.West;

            var expectedResult = new SimpleMartianRobot("TestRobot", position, orientation);

            var target = new RobotDataParser();

            // Act.
            var actualResult = target.ParseRobotData(robotDataString);

            // Assert.
            Assert.IsNotNull(actualResult);
            Assert.AreEqual(expectedResult.CurrentPosition, actualResult.CurrentPosition);
            Assert.AreEqual(expectedResult.Orientation, actualResult.Orientation);
        }
    }
}
