using System;
using System.Collections.Generic;
using System.Linq;

using MartianResearchingSystem.Core.Robots;
using MartianResearchingSystem.Utils;

namespace MartianResearchingSystem.Core.Parsers
{
	/// <summary>
	/// Парсер команд для робота.
	/// </summary>
	public class CommandsParser
	{
		/// <summary>
		/// Выполняет парсинг строки, содержащей команды для робота.
		/// </summary>
		/// <param name="data">Строка, содержащая команды для робота.</param>
		/// <returns>Список команд <see cref="Command"/>.</returns>
		public List<Command> ParseCommandString(string data)
		{
			Guard.ArgumentIsNotNullOrWhiteSpace(data, nameof(data));

            var commandsString = data
                .ToUpperInvariant()
                .Where(char.IsLetter)
                .Select(_ => _.ToString())
                .ToArray();

			var commands = data
				.Select(_ => ParseCommand(_))
                .ToList();

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
					throw new InvalidOperationException("Invalid command. Cannot parse.");
				}
			}
		}
	}
}
