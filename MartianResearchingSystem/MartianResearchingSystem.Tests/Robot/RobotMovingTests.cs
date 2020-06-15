using MartianResearchingSystem.Core.Spacing;
using MartianResearchingSystem.Tests.TestClasses;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MartianResearchingSystem.Tests.Robot
{
    [TestClass]
    public class RobotMovingTests
    {
        [TestMethod]
        public void Should_Move_To_North_Correctly()
        {
            // Arrange.
            var position = new Position(1, 2);
            var expectedPosition = new Position(1, 3);
            var orientation = Orientation.North;

            var target = new TestRobot("Test robot", position, orientation);

            // Act.
            target.Move();

            // Assert.
            Assert.AreEqual(expectedPosition, target.CurrentPosition);
        }

        [TestMethod]
        public void Should_Move_To_South_Correctly()
        {
            // Arrange.
            var position = new Position(1, 2);
            var expectedPosition = new Position(1, 1);
            var orientation = Orientation.South;

            var target = new TestRobot("Test robot", position, orientation);

            // Act.
            target.Move();

            // Assert.
            Assert.AreEqual(expectedPosition, target.CurrentPosition);
        }

        [TestMethod]
        public void Should_Move_To_West_Correctly()
        {
            // Arrange.
            var position = new Position(1, 2);
            var expectedPosition = new Position(0, 2);
            var orientation = Orientation.West;

            var target = new TestRobot("Test robot", position, orientation);

            // Act.
            target.Move();

            // Assert.
            Assert.AreEqual(expectedPosition, target.CurrentPosition);
        }

        [TestMethod]
        public void Should_Move_To_East_Correctly()
        {
            // Arrange.
            var position = new Position(1, 2);
            var expectedPosition = new Position(2, 2);
            var orientation = Orientation.East;

            var target = new TestRobot("Test robot", position, orientation);

            // Act.
            target.Move();

            // Assert.
            Assert.AreEqual(expectedPosition, target.CurrentPosition);
        }
    }
}
