using System;
using System.Collections.Generic;
using System.Linq;
using MartianResearchingSystem.Core.Command;
using MartianResearchingSystem.Core.Positioning;
using MartianResearchingSystem.Core.Robot;
using MartianResearchingSystem.Core.Surface;

namespace MartianResearchingSystem.Core
{
	public class ResearchSession
	{
		public MarsSurface MarsSurface { get; set; }

		public Dictionary<Robot.Robot, List<Command.Command>> ThingsToDo { get; set; }

		public List<Robot.Robot> Robots { get; set; }


		public void Process()
		{
			foreach (var thingToDo in ThingsToDo)
			{
				var robot = thingToDo.Key;
				var commandsToExecute = thingToDo.Value;

				foreach (var command in commandsToExecute)
				{
					if (command != Command.Command.MoveForward)
					{
						robot.ExecuteCommand(command);

						continue;
					}

					var previousPosition = robot.CurrentPosition;

					var newPosition = robot.GetNewPosition();

					if (IsOutside(newPosition))
					{
						if (MarsSurface.IsPositionScented(previousPosition))
						{
							continue;
						}

						robot.IsLost = true;

						MarsSurface.AddScentedPosition(previousPosition);

						break;
					}
					else
					{
						robot.ExecuteCommand(command);
					}
				}
			}
		}


		private bool IsOutside(Position position) => position.XCoord > MarsSurface.Width || position.YCoord > MarsSurface.Length;
	}
}
