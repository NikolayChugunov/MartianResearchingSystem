using System;
using System.Linq;

using MartianResearchingSystem.Core.Robots;
using MartianResearchingSystem.Core.Spacing;
using MartianResearchingSystem.Utils;

namespace MartianResearchingSystem.Core.Parsers
{
	/// <summary>
	/// Парсер данных робота.
	/// </summary>
	public class RobotDataParser
	{
		/// <summary>
		/// Парсит строку с данными в робота.
		/// </summary>
		/// <param name="line">Строка с необходимыми данными.</param>
		/// <returns>Робота <see cref="SimpleMartianRobot"/>.</returns>
		public SimpleMartianRobot ParseRobotData(string line)
		{
			line = Guard.ArgumentIsNotNullOrWhiteSpace(line, nameof(line));

            var inputs = line
                .ToUpperInvariant()
                .Where(char.IsLetterOrDigit)
                .Select(_ => _.ToString())
                .ToArray();

            var xPos = Convert.ToInt32(inputs[0]);
            var yPos = Convert.ToInt32(inputs[1]);

			Orientation robotOrientation;

			switch(inputs[2])
			{
                case "N":
				{
					robotOrientation = Orientation.North;

					break;
				}
                case "E":
				{
					robotOrientation = Orientation.East;

					break;
				}
                case "S":
				{
					robotOrientation = Orientation.South;

					break;
				}

                case "W":
				{
					robotOrientation = Orientation.West;

					break;
				}
				default:
				{
					throw new ArgumentException("Invalid orientation. Cannot parse.");
				}	
			}

			var position = new Position(xPos, yPos);

			var newRobot = new SimpleMartianRobot("Test robot", position, robotOrientation);

			return newRobot;
		}
	}
}
