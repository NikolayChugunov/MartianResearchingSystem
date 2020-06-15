using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MartianResearchingSystem.Core.Robots;
using MartianResearchingSystem.Core.Spacing;
using MartianResearchingSystem.Tests.TestClasses;

namespace MartianResearchingSystem.Tests.Robot
{
    [TestClass]
    public class RobotCommandExecutionTests
    {
        [TestMethod]
        public void Should_Execute_TurnLeft_Command_Correctly()
        {
            // Arrange.
            var position = new Position(2, 2);
            var orientation = Orientation.North;
            var expectedOrientation = Orientation.West;

            var target = new TestRobot("Test robot", position, orientation);

            // Act.
            target.ExecuteCommand(Command.TurnLeft);

            // Assert.
            Assert.AreEqual(expectedOrientation, target.Orientation);
            Assert.AreEqual(position, target.CurrentPosition);
        }

        [TestMethod()]
        public void Should_Execute_TurnRight_Command_Correctly()
        {
            // Arrange.
            var position = new Position(2, 2);
            var orientation = Orientation.West;
            var expectedOrientation = Orientation.North;

            var target = new TestRobot("Test robot", position, orientation);

            // Act.
            target.ExecuteCommand(Command.TurnRight);

            // Assert.
            Assert.AreEqual(expectedOrientation, target.Orientation);
            Assert.AreEqual(position, target.CurrentPosition);
        }

        [TestMethod()]
        public void Should_Execute_MoveForward_Command_Correctly()
        {
            // Arrange.
            var position = new Position(2, 3);
            var orientation = Orientation.West;
            var expectedPosition = new Position(1, 3);

            var target = new TestRobot("Test robot", position, orientation);

            // Act.
            target.ExecuteCommand(Command.MoveForward);

            // Assert.
            Assert.AreEqual(orientation, target.Orientation);
            Assert.AreEqual(expectedPosition, target.CurrentPosition);
        }

        [TestMethod]
        public void Should_Execute_Queue_OfCommands_Correctly()
        {
            // Arrange.
            var position = new Position(1, 1);
            var orientation = Orientation.East;

            var commands = new List<Command>
            {
                Command.TurnRight,
                Command.MoveForward,
                Command.TurnRight,
                Command.MoveForward,
                Command.TurnRight,
                Command.MoveForward,
                Command.TurnRight,
                Command.MoveForward
            };

            var expectedPosition = new Position(1, 1);
            var expectedOrientation = Orientation.East;

            var target = new TestRobot("Test robot", position, orientation);

            // Act.
            foreach(var command in commands)
            {
                target.ExecuteCommand(command);
            }

            // Assert.
            Assert.AreEqual(expectedPosition, target.CurrentPosition);
            Assert.AreEqual(expectedOrientation, target.Orientation);
        }
    }
}
