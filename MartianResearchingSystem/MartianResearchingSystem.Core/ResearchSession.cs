using System.Collections.Generic;

using MartianResearchingSystem.Core.Robots;
using MartianResearchingSystem.Core.Spacing;

namespace MartianResearchingSystem.Core
{
    /// <summary>
    /// Исследовательская сессия на Марсе.
    /// </summary>
    public class ResearchSession
    {
        /// <summary>
        /// Поверхность Марса.
        /// </summary>
        public MarsSurface MarsSurface { get; set; }

        /// <summary>
        /// Роботы, высаживаемые на поверхность и набор инструкций для каждого.
        /// </summary>
        public Dictionary<SimpleMartianRobot, List<Command>> Operands { get; set; }

        /// <summary>
        /// Осуществляет выполнение сессии
        /// </summary>
        public void Execute()
        {
            foreach (var operand in Operands)
            {
                var robot = operand.Key;
                var commandsToExecute = operand.Value;

                foreach (var command in commandsToExecute)
                {
                    var previousPosition = robot.CurrentPosition;

                    robot.ExecuteCommand(command);

                    var newPosition = robot.CurrentPosition;

                    if (!IsOutside(newPosition))
                    {
                        continue;
                    }

                    if (MarsSurface.IsPositionScented(previousPosition))
                    {
                        robot.CurrentPosition = previousPosition;

                        continue;
                    }

                    robot.IsLost = true;
                    robot.CurrentPosition = previousPosition;

                    MarsSurface.AddScentedPosition(previousPosition);
                    
                    break;
                }
            }
        }

        /// <summary>
        /// Определяет, является ли позиция вышедшей за пределы поверхности Марса.
        /// </summary>
        /// <param name="position">Проверяемая позиция.</param>
        /// <returns>true, если позиция выходит за пределы Марса, в противном случае - false.</returns>
        private bool IsOutside(Position position) => position.XCoord < 0
            || position.XCoord > MarsSurface.Length
            || position.YCoord < 0
            || position.YCoord > MarsSurface.Width;
    }
}
