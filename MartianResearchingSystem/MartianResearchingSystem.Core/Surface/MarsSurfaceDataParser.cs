using System;
using MartianResearchingSystem.Utils;

namespace MartianResearchingSystem.Core.Surface
{
	/// <summary>
	/// Пармер данных для поверхности Марса.
	/// </summary>
	public class MarsSurfaceDataParser
	{
		/// <summary>
		/// Выполняет парсинг строки в поверхность Марса с заданными в строке размерами.
		/// </summary>
		/// <param name="data">Данные для парсинга.</param>
		/// <returns>Поверхность марса <see cref="MarsSurface"/> с указанными размерами.</returns>
		public MarsSurface ParseMarsSurface(string data)
		{
			data = Guard.ArgumentIsNotNullOrWhiteSpace(data, nameof(data));

			var sizes = data.Split(' ');

			var xDimensionSize = Convert.ToInt32(sizes[0]);
			var yDimensionSize = Convert.ToInt32(sizes[1]);

			var surface = new MarsSurface(yDimensionSize, xDimensionSize);

			return surface;
		}
	}
}
