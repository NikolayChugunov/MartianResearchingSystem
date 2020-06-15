using System;
using MartianResearchingSystem.Core.Spacing;
using MartianResearchingSystem.Tests.TestClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MartianResearchingSystem.Tests.Robot
{
    [TestClass]
    public class RobotRotationTests
    {
        [TestMethod]
        public void Should_RotateClockwise_Correctly()
        {
            // Arrange.
            var position = new Position(0, 0);
            var orientation = Orientation.East;
            var expectedOrientation = Orientation.South;

            var target = new TestRobot("Test Robot", position, orientation);

            // Act.
            target.RotateClockwise();

            // Assert.
            Assert.AreEqual(position, target.CurrentPosition);
            Assert.AreEqual(expectedOrientation, target.Orientation);

        }

        [TestMethod]
        public void Should_RotateClockwise_WhenCornerCase_Correctly()
        {
            // Arrange.
            var position = new Position(0, 0);
            var orientation = Orientation.West;
            var expectedOrientation = Orientation.North;

            var target = new TestRobot("Test Robot", position, orientation);

            // Act.
            target.RotateClockwise();

            // Assert.
            Assert.AreEqual(position, target.CurrentPosition);
            Assert.AreEqual(expectedOrientation, target.Orientation);
        }

        [TestMethod]
        public void Should_RotateCounterClockwise_Correctly()
        {
            // Arrange.
            var position = new Position(0, 0);
            var orientation = Orientation.South;
            var expectedOrientation = Orientation.East;

            var target = new TestRobot("Test Robot", position, orientation);

            // Act.
            target.RotateCounterClockwise();

            // Assert.
            Assert.AreEqual(position, target.CurrentPosition);
            Assert.AreEqual(expectedOrientation, target.Orientation);
        }

        [TestMethod]
        public void Should_RotateCounterClockwise_WhenCornerCase_Correctly()
        {
            // Arrange.
            var position = new Position(0, 0);
            var orientation = Orientation.North;
            var expectedOrientation = Orientation.West;

            var target = new TestRobot("Test robot", position, orientation);

            // Act.
            target.RotateCounterClockwise();

            // Assert.
            Assert.AreEqual(position, target.CurrentPosition);
            Assert.AreEqual(expectedOrientation, target.Orientation);
        }
    }
}
