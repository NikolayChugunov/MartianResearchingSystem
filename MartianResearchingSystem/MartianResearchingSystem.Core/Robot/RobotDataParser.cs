using System;
using MartianResearchingSystem.Core.Positioning;
using MartianResearchingSystem.Utils;

namespace MartianResearchingSystem.Core.Robot
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
		/// <returns>Робота <see cref="Robot"/>.</returns>
		public Robot ParseRobotData(string line)
		{
			line = Guard.ArgumentIsNotNullOrWhiteSpace(line, nameof(line));

			var inputs = line.Split(' ');
			
			var xPos = int.Parse(inputs[0]);
			var yPos = int.Parse(inputs[1]);

			SpaceOrientation robotOrientation;

			switch(inputs[2])
			{
                case "N":
				{
					robotOrientation = SpaceOrientation.North;

					break;
				}
                case "E":
				{
					robotOrientation = SpaceOrientation.East;

					break;
				}
                case "S":
				{
					robotOrientation = SpaceOrientation.South;

					break;
				}
                    
                case "W":
				{
					robotOrientation = SpaceOrientation.West;

					break;
				}
				default:
				{
					throw new ArgumentException("Invalid orientation");
				}	
			}

			var position = new Position(xPos, yPos);

			var newRobot = new Robot("Test robot", position, robotOrientation);

			return newRobot;
		}
	}
}
