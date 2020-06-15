using System;
using MartianResearchingSystem.Core.Command;
using MartianResearchingSystem.Core.Positioning;
using MartianResearchingSystem.Utils;

namespace MartianResearchingSystem.Core.Robot
{
	/// <summary>
	/// Описывает робота, высаживаемого на поверхность Марса.
	/// </summary>
	public class Robot
	{
		/// <summary>
		/// Инициализирует новый экземпляр робота <see cref="Robot"/>.
		/// </summary>
		/// <param name="name">Имя робота.</param>
		/// <param name="startPosition">Начальная позиция робота.</param>
		/// <param name="startOrientation">Начальная ориентация робота.</param>
		public Robot(string name, Position startPosition, SpaceOrientation startOrientation)
		{
			Id = Guid.NewGuid();
			Name = Guard.ArgumentIsNotNullOrWhiteSpace(name, nameof(name));
			CurrentPosition = startPosition;
			Orientation = startOrientation;
			IsLost = false;
		}

		/// <summary>
		/// Идентификатор робота.
		/// </summary>
		public Guid Id { get; }

		/// <summary>
		/// Имя робота.
		/// </summary>
		public string Name { get; }

		/// <summary>
		/// Текущая позиция робота на поверхности Марса.
		/// </summary>
		public Position CurrentPosition { get; set; }

		/// <summary>
		/// ориентация робота.
		/// </summary>
		public SpaceOrientation Orientation { get; set; }

		/// <summary>
		/// Определяет, является ли робот потерянным.
		/// </summary>
		public bool IsLost { get; set; }

		/// <summary>
		/// Осуществляет выполнение команды робота.
		/// </summary>
		/// <param name="commandToExecute">Команда к исполнению.</param>
		public void ExecuteCommand(Command.Command commandToExecute)
		{
			switch (commandToExecute)
			{
				case Command.Command.MoveForward:
				{
						Move();

					break;
				}
				case Command.Command.TurnRight:
				{
						RotateClockwise();

					break;
				}
				case Command.Command.TurnLeft:
				{
						RotateCounterClockwise();

					break;
				}
				default:
				{
					throw new InvalidOperationException("Invalid command.");
				}
			}
		}

		/// <summary>
		/// Осуществляет передвижение робота в соответствии с инструкцией.
		/// </summary>
		private void Move()
		{
			var newPosition = GetNewPosition();

			CurrentPosition = newPosition;
		}

		/// <summary>
		/// Осуещствляет вычисление новых координат позиции для робота.
		/// </summary>
		/// <returns></returns>
		public Position GetNewPosition()
		{
			var currentXCoord = CurrentPosition.XCoord;
			var currentYCoord = CurrentPosition.YCoord;

			switch (Orientation)
			{
				case SpaceOrientation.North:
					{
						currentYCoord++;

						break;
					}
				case SpaceOrientation.South:
					{
						currentYCoord--;

						break;
					}
				case SpaceOrientation.West:
					{
						currentXCoord--;

						break;
					}
				case SpaceOrientation.East:
					{
						currentXCoord++;

						break;
					}
			}

			var position = new Position(currentXCoord, currentYCoord);

			return position;
		}


		/// <summary>
		/// Разворачивает робота на 90 градусов по часовой стрелке.
		/// </summary>
		private void RotateClockwise()
		{
			Orientation = Orientation == SpaceOrientation.West
				? SpaceOrientation.North
				: ++Orientation;
		}

		/// <summary>
		/// Разворачивает робота на 90 градусов против часовой стрелки.
		/// </summary>
		private void RotateCounterClockwise()
		{
			Orientation = Orientation == SpaceOrientation.North
				? SpaceOrientation.West
				: --Orientation;
		}

		/// <summary>
		/// выводит текущую информацию о роботе.
		/// </summary>
		public override string ToString()
		{
			return $"Robot: {Name} (ID={Id}) - Position: {CurrentPosition}, Orientation: {Orientation.GetDescription()} LOST:{IsLost}";
		}
	}
}
