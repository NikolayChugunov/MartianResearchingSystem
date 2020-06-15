using MartianResearchingSystem.Core.Robots;
using MartianResearchingSystem.Core.Spacing;

namespace MartianResearchingSystem.Tests.TestClasses
{
    public class TestRobot : SimpleMartianRobot
    {
        public TestRobot(string name, Position position, Orientation orientation) : base(name, position, orientation) { }

        public new void RotateClockwise()
        {
            base.RotateClockwise();
        }

        public new void RotateCounterClockwise()
        {
            base.RotateCounterClockwise();
        }

        public new void Move()
        {
            base.Move();
        }
    }
}
