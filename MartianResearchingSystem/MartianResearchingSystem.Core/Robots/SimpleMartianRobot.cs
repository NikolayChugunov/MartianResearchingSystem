using System;
using MartianResearchingSystem.Core.Spacing;
using MartianResearchingSystem.Utils;

namespace MartianResearchingSystem.Core.Robots
{
	/// <summary>
	/// Описывает робота, высаживаемого на поверхность Марса.
	/// </summary>
	public class SimpleMartianRobot
	{
		/// <summary>
		/// Инициализирует новый экземпляр робота <see cref="SimpleMartianRobot"/>.
		/// </summary>
		/// <param name="name">Имя робота.</param>
		/// <param name="startPosition">Начальная позиция робота.</param>
		/// <param name="startOrientation">Начальная ориентация робота.</param>
		public SimpleMartianRobot(string name, Position startPosition, Orientation startOrientation)
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
		public Orientation Orientation { get; set; }

		/// <summary>
		/// Определяет, является ли робот потерянным.
		/// </summary>
		public bool IsLost { get; set; }

		/// <summary>
		/// Осуществляет выполнение команды робота.
		/// </summary>
		/// <param name="commandToExecute">Команда к исполнению.</param>
		public void ExecuteCommand(Command commandToExecute)
		{
			switch (commandToExecute)
			{
				case Command.MoveForward:
				{
					Move();

					break;
				}
				case Command.TurnRight:
				{
					RotateClockwise();

					break;
				}
				case Command.TurnLeft:
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
		protected void Move()
		{
			var newPosition = GetNewPosition();

			CurrentPosition = newPosition;
		}

		/// <summary>
		/// Осуещствляет вычисление новых координат позиции для робота.
		/// </summary>
		/// <returns></returns>
		private Position GetNewPosition()
		{
			var currentXCoord = CurrentPosition.XCoord;
			var currentYCoord = CurrentPosition.YCoord;

			switch (Orientation)
			{
				case Orientation.North:
				{
				    currentYCoord++;

					break;
				}
				case Orientation.South:
				{
				    currentYCoord--;

					break;
				}
				case Orientation.West:
				{
					currentXCoord--;

					break;
				}
				case Orientation.East:
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
		protected void RotateClockwise()
		{
			Orientation = Orientation == Orientation.West
				? Orientation.North
				: ++Orientation;
		}

		/// <summary>
		/// Разворачивает робота на 90 градусов против часовой стрелки.
		/// </summary>
		protected void RotateCounterClockwise()
		{
			Orientation = Orientation == Orientation.North
				? Orientation.West
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
