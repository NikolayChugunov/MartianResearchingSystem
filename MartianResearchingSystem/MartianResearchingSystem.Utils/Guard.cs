using System;

namespace MartianResearchingSystem.Utils
{
	public static class Guard
	{
		/// <summary>
		/// Проверяет, является ли переданный аргумент больше нуля.
		/// Выбрасывает исключение <see cref="ArgumentException"/>, если это не так.
		/// </summary>
		/// <param name="arg">Анализируемый аргумент.</param>
		/// <param name="argName">Имя аргумента.</param>
		/// <returns>Проверенное значение - если валидно, иначе выбрасывает исключение <see cref="ArgumentException"/>.</returns>
		public static int ArgumentGreaterThanZero(int arg, string argName)
		{
			if (arg <= default(int))
			{
				throw new ArgumentException("Значение должно быть больше нуля.", argName);
			}

			return arg;
		}

		/// <summary>
		/// Проверяет, является ли переданный аргумент эквивалентным null, является ли пустой строкой
		/// или строкой, состоящей только из пробелов.
		/// Выбрасывает исключение <see cref="ArgumentException"/>, если это так.
		/// </summary>
		/// <param name="arg">Проверяемый аргумент.</param>
		/// <param name="argName">Имя аргумента.</param>
		/// <returns>Проверенное значение - если валидно, иначе выбрасывает исключение <see cref="ArgumentException"/>.</returns>
		public static string ArgumentIsNotNullOrWhiteSpace(string arg, string argName)
		{
			if (arg.IsNullOrWhiteSpace())
			{
				throw new ArgumentException("Строковое значение должно быть заполнено", argName);
			}

			return arg;
		}
	}
}
