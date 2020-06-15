using System;
using System.Collections.Generic;
using System.Linq;
using MartianResearchingSystem.Utils;

namespace MartianResearchingSystem.Core.Command
{
	/// <summary>
	/// Парсер команд для робота.
	/// </summary>
	public class CommandsParser
	{
		/// <summary>
		/// Выполняет парсинг строки, содержащей команды для робота.
		/// </summary>
		/// <param name="commandString">Строка, содержащая команды для робота.</param>
		/// <returns>Список команд <see cref="Command"/>.</returns>
		public List<Command> ParseCommandString(string commandString)
		{
			Guard.ArgumentIsNotNullOrWhiteSpace(commandString, nameof(commandString));

			var commands = commandString
				.Select(_ => ParseCommand(_)).ToList();

			return commands;
		}

		/// <summary>
		/// Выполняет парсинг одного символа в команду.
		/// </summary>
		/// <param name="commandChar">Символ команды.</param>
		/// <returns>Команда <see cref="Command"/>, или же исключение <see cref="InvalidOperationException"/>.</returns>
		public Command ParseCommand(char commandChar)
		{
			switch (char.ToUpper(commandChar))
			{
				case 'R':
				{
					return Command.TurnRight;
				}
				case 'L':
				{
					return Command.TurnLeft;
				}
				case 'F':
				{
					return Command.MoveForward;
				}
				default:
				{
					throw new InvalidOperationException("Недопустимая команда.");
				}
			}
		}
	}
}
